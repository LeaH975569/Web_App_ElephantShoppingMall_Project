using Microsoft.AspNetCore.Mvc;

namespace A22nd.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
