using A22nd.ViewModels;
using Microsoft.AspNetCore.Mvc;
using A22nd.Models;

namespace A22nd.Controllers
{
    public class HomeController : Controller
    {
        private readonly IStoreRepository _storerepository;
        public HomeController(IStoreRepository storerepository)
        {
            _storerepository = storerepository;
        }

        public IActionResult Index()
        {
            return View();
        }

    }
}
