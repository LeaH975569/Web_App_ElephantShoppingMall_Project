using A22nd.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace A22nd.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private readonly IOrderRepository _orderRepository;

        public OrderController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }


        public IActionResult Checkout()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Checkout(Order order)
        {          

            if (ModelState.IsValid)
            {
                _orderRepository.CreateOrder(order, HttpContext.Session.GetInt32("storeid").Value, HttpContext.Session.GetInt32("giftCardid").Value);
                return RedirectToAction("CheckoutComplete");
            }
            return View();
            
        }

        public IActionResult CheckoutComplete()
        {
            ViewBag.CheckoutCompleteMessage = "Thanks for your order. We will get intouch with you when the gift card is ready to collect!";
            return View();
        }

    }
}
