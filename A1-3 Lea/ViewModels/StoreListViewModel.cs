using A22nd.Models;

namespace A22nd.ViewModels
{
    public class StoreListViewModel
    {
        public IEnumerable<Store> Stores { get; }
        public string? CurrentCategory { get; }
 
        public StoreListViewModel(IEnumerable<Store> stores, string? currentCategory)
        {
            Stores = stores;
            CurrentCategory = currentCategory;
        }
    }
}
