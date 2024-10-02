using System.IO.Pipelines;


namespace A22nd.Models
{
    public interface IShoppingCart
    {
        List<ShoppingCartItem> GetShoppingCartItems();
        string ShoppingCartId { get; }
        List<ShoppingCartItem> ShoppingCartItems { get; set; }
        decimal GetShoppingCartTotal();
        void AddToCart(GiftCard giftCard, int amount, Store store);
        void ClearCart();
        int RemoveFromCart(GiftCard giftCard);
        /*
        void AddToCart(GiftCard giftCard);
        int RemoveFromCart(Pie pie);       
        void ClearCart();
        */

    }
}
