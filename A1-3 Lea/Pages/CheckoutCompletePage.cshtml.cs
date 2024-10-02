using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace A22nd.Pages
{
    public class CheckoutCompletePageModel : PageModel
    {
        public void OnGet()
        {
            ViewData["CheckoutCompleteMessage"] = "Thanks for your order. We will get intouch with you when the gift card is ready to collect!";
        }
    }
}
