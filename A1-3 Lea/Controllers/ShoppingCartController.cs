using Microsoft.AspNetCore.Mvc;
using A22nd.Models;
using A22nd.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace A22nd.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly MallStoreDbContext _mallStoreDbContext;
        private readonly IShoppingCart _shoppingCart;
        private readonly IStoreRepository _storeRepository;
        private readonly IGiftCardRepository _giftCardRepository;

        public ShoppingCartController(IShoppingCart shoppingCart, IStoreRepository storeRepository, IGiftCardRepository giftCardRepository, MallStoreDbContext mallStoreDbContext)
        {
            _shoppingCart = shoppingCart;
            _storeRepository = storeRepository;
            _giftCardRepository = giftCardRepository;
            _mallStoreDbContext = mallStoreDbContext;
        }

        public IActionResult Index()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;

            var shoppingCartViewModel = new ShoppingCartViewModel(_shoppingCart, _shoppingCart.GetShoppingCartTotal())
            {
                Stores = _storeRepository.AllStores
            };

            return View(shoppingCartViewModel);
        }

        public IActionResult AddToCart(int giftCardId, int storeId)
        {
            var selectedGiftCard = _giftCardRepository.AllGiftCards.FirstOrDefault(p => p.GiftCardId == giftCardId);
            var selectedStore = _storeRepository.AllStores.FirstOrDefault(s => s.StoreId == storeId);

            if (selectedGiftCard != null && selectedStore != null)
            {
                var shoppingCartId = _shoppingCart.ShoppingCartId;
                var shoppingCartItem = _mallStoreDbContext.ShoppingCartItems.SingleOrDefault(
                    s => s.GiftCard.GiftCardId == giftCardId && s.ShoppingCartId == shoppingCartId);

                if (shoppingCartItem == null)
                {
                    shoppingCartItem = new ShoppingCartItem
                    {
                        ShoppingCartId = shoppingCartId,
                        GiftCard = selectedGiftCard,
                        Amount = 1,
                        SelectedStore = selectedStore
                    };

                    _mallStoreDbContext.ShoppingCartItems.Add(shoppingCartItem);
                }
                else
                {
                    shoppingCartItem.Amount++;
                }

                _mallStoreDbContext.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        public IActionResult RemoveFromCart(int giftCardId)
    {
        var selectedGiftCard = _giftCardRepository.AllGiftCards.FirstOrDefault(p => p.GiftCardId == giftCardId);

        if (selectedGiftCard != null)
        {
            _shoppingCart.RemoveFromCart(selectedGiftCard);
        }

        return RedirectToAction("Index");
    }

    /*
    public RedirectToActionResult RemoveFromShoppingCart(int pieId)
    {
        var selectedPie = _pieRepository.AllPies.FirstOrDefault(p => p.PieId == pieId);
        if (selectedPie != null)
        {
            _shoppingCart.RemoveFromCart(selectedPie);
        }
        return RedirectToAction("Index");
    }

    */
}

}
