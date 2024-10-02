using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace A22nd.Controllers
{
    [Authorize]
    public class MemberController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
