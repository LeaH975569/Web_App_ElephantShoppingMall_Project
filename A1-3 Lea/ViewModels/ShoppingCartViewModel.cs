using A22nd.Models;

namespace A22nd.ViewModels
{
    public class ShoppingCartViewModel
    {
        public IShoppingCart ShoppingCart { get; set; }
        public decimal ShoppingCartTotal { get; set; }
        public IEnumerable<Store> Stores { get; set; }
        public ShoppingCartViewModel()
        {
            Stores = new List<Store>();
        }

        public ShoppingCartViewModel(IShoppingCart shoppingCart, decimal shoppingCartTotal)
        {
            ShoppingCart = shoppingCart;
            ShoppingCartTotal = shoppingCartTotal;
            Stores = new List<Store>();
        }
    }
}
