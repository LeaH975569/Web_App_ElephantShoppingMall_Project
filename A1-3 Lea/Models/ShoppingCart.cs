using System.IO.Pipelines;
using Microsoft.EntityFrameworkCore;

namespace A22nd.Models
{
    public class ShoppingCart : IShoppingCart
    {
        private readonly MallStoreDbContext _mallStoreDbContext;
        private ShoppingCart(MallStoreDbContext mallStoreDbContext)
        {
            _mallStoreDbContext = mallStoreDbContext;
        }

        public List<ShoppingCartItem> ShoppingCartItems { get; set; } = default;

        //Declare ShoppingCartId
        public string? ShoppingCartId { get; set; }

        public static ShoppingCart GetCart(IServiceProvider services)
        {
            ISession? session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext?.Session;
            MallStoreDbContext context = services.GetService<MallStoreDbContext>() ?? throw new Exception("Error initializing");
            string cartId = session?.GetString("CartId") ?? Guid.NewGuid().ToString();
            session?.SetString("CartId", cartId);
            return new ShoppingCart(context) { ShoppingCartId = cartId };
        }

        public List<ShoppingCartItem> GetShoppingCartItems()
        {
            return ShoppingCartItems ??=
             _mallStoreDbContext.ShoppingCartItems.Where(c => c.ShoppingCartId == ShoppingCartId)
                                       .Include(s => s.GiftCard)
                                       .ToList();
        }

        public decimal GetShoppingCartTotal()
        {
            var total = _mallStoreDbContext.ShoppingCartItems.Where(c => c.ShoppingCartId == ShoppingCartId)
                .Select(c => c.GiftCard.GiftCardPrice).Sum();
            return total;
        }



        public void AddToCart(GiftCard giftCard, int amount, Store store)
        {
            var shoppingCartItem = _mallStoreDbContext.ShoppingCartItems.SingleOrDefault(
                s => s.GiftCard.GiftCardId == giftCard.GiftCardId && s.ShoppingCartId == ShoppingCartId);

            if (shoppingCartItem == null)
            {
                shoppingCartItem = new ShoppingCartItem
                {
                    ShoppingCartId = ShoppingCartId,
                    GiftCard = giftCard,
                    Amount = amount,
                    SelectedStore = store
                };

                _mallStoreDbContext.ShoppingCartItems.Add(shoppingCartItem);
            }
            else
            {
                shoppingCartItem.Amount++;
            }

            _mallStoreDbContext.SaveChanges();
        }

        public int RemoveFromCart(GiftCard giftCard)
        {
            var shoppingCartItem = _mallStoreDbContext.ShoppingCartItems.SingleOrDefault(
                s => s.GiftCard.GiftCardId == giftCard.GiftCardId && s.ShoppingCartId == ShoppingCartId);

            var localAmount = 0;

            if (shoppingCartItem != null)
            {
                if (shoppingCartItem.Amount > 1)
                {
                    shoppingCartItem.Amount--;
                    localAmount = shoppingCartItem.Amount;
                }
                else
                {
                    _mallStoreDbContext.ShoppingCartItems.Remove(shoppingCartItem);
                }
            }

            _mallStoreDbContext.SaveChanges();

            return localAmount;
        }


        public void ClearCart()
        {
            var cartItems = _mallStoreDbContext.ShoppingCartItems.Where(cart => cart.ShoppingCartId == ShoppingCartId);

            _mallStoreDbContext.ShoppingCartItems.RemoveRange(cartItems);

            _mallStoreDbContext.SaveChanges();
        }


        /*

        public int RemoveFromCart(Pie pie)
        {
            var shoppingCartItem =
                _bethanysPieShopDbContext.ShoppingCartItems.SingleOrDefault(
                    s => s.Pie.PieId == pie.PieId && s.ShoppingCartId == ShoppingCartId);

            var localAmount = 0;

            if (shoppingCartItem != null)
            {
                if (shoppingCartItem.Amount > 1)
                {
                    shoppingCartItem.Amount--;
                    localAmount = shoppingCartItem.Amount;
                }
                else
                {
                    _bethanysPieShopDbContext.ShoppingCartItems.Remove(shoppingCartItem);
                }
            }
            _bethanysPieShopDbContext.SaveChanges();
            return localAmount;
        }



        public void ClearCart()
        {
            var cartItems = _bethanysPieShopDbContext
                .ShoppingCartItems
                .Where(cart => cart.ShoppingCartId == ShoppingCartId);

            _bethanysPieShopDbContext.ShoppingCartItems.RemoveRange(cartItems);
            _bethanysPieShopDbContext.SaveChanges();
        }

        */

    }
}

