using A22nd.ViewModels;
using Microsoft.AspNetCore.Mvc;
using A22nd.Models;

namespace A22nd.Components
{
    public class StoreSelectMenu : ViewComponent
    {
        private readonly IStoreRepository _storeRepository;
    public StoreSelectMenu(IStoreRepository storeRepository)
    {
        _storeRepository = storeRepository;
    }
    public IViewComponentResult Invoke()
    {
        var categories = _storeRepository.AllStores.OrderBy(c => c.Name);
        return View(categories);
    }
}
}
