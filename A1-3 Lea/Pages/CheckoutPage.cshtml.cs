using A22nd.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace A22nd.Pages
{
    public class CheckoutPageModel : PageModel
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IGiftCardRepository _giftCardRepository;
        private readonly IStoreRepository _storeRepository;

        public CheckoutPageModel(IOrderRepository orderRepository, IGiftCardRepository giftCardRepository, IStoreRepository storeRepository)
        {
            _orderRepository = orderRepository;
            _giftCardRepository = giftCardRepository;
            _storeRepository = storeRepository;
        }

        [BindProperty]
        public Order Order { get; set; }

        [BindProperty]
        public int SelectedGiftCardId { get; set; }

        [BindProperty]
        public int SelectedStoreId { get; set; }

        public IEnumerable<GiftCard> GiftCards { get; set; }
        public IEnumerable<Store> Stores { get; set; }

        public void OnGet()
        {
            GiftCards = _giftCardRepository.AllGiftCards;
            Stores = _storeRepository.AllStores;
        }

        public IActionResult OnPost()
        {
            if (SelectedGiftCardId == 0 || SelectedStoreId == 0)
            {
                ModelState.AddModelError("", "Please select a gift card value and a store.");
                GiftCards = _giftCardRepository.AllGiftCards;
                Stores = _storeRepository.AllStores;
                return Page();
            }

            if (ModelState.IsValid)
            {
                _orderRepository.CreateOrder(Order, SelectedGiftCardId, SelectedStoreId);
                return RedirectToPage("CheckoutCompletePage");
            }

            GiftCards = _giftCardRepository.AllGiftCards;
            Stores = _storeRepository.AllStores;
            return Page();
        }
    }
}