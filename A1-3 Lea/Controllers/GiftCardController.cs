using A22nd.Models;
using A22nd.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO.Pipelines;

namespace A22nd.Controllers
{
	public class GiftCardController : Controller
	{

        private readonly IStoreRepository _storeRepository;
        private readonly IGiftCardRepository _giftCardRepository;

		public GiftCardController(IGiftCardRepository giftCardRepository, IStoreRepository storeRepository)
		{
            _storeRepository = storeRepository;
            _giftCardRepository = giftCardRepository;
		}

        [HttpPost]
        public IActionResult Index(int selectedGiftCardId, int selectedStoreId)
        {
            var session = HttpContext.Session;
            session.SetInt32("storeid", selectedStoreId);
            session.SetInt32("giftCardid", selectedGiftCardId);
            return Redirect("Order/Checkout");
        }

        public IActionResult Index(string store)
        {
            IEnumerable<GiftCard> giftCards;
            string? currentStore;

            if (string.IsNullOrEmpty(store))
            {
                giftCards = _giftCardRepository.AllGiftCards.OrderBy(p => p.GiftCardId);
                currentStore = "All stores";
            }
            else
            {
                giftCards = _giftCardRepository.AllGiftCards.Where(p => p.Store.Name == store)
                     .OrderBy(p => p.GiftCardId);
                currentStore = _storeRepository.AllStores.FirstOrDefault(c => c.Name == store)?.Name;
            }

            var giftCardViewModel = new GiftCardViewModel
            {
                GiftCards = giftCards,
                Stores = _storeRepository.AllStores,
                CurrentStore = currentStore
            };

            return View(giftCardViewModel);
        }

        public IActionResult Details(int id)
        {
            var giftCard = _giftCardRepository.GetGiftCardById(id);
            if (giftCard == null)
            {
                return NotFound();
            }
            return View(giftCard);
        }

        /*
        public ViewResult List(string store)
        {
            IEnumerable<GiftCard> giftCards;
            string? currentStore;
            if (string.IsNullOrEmpty(store))
            {
                giftCards = _giftCardRepository.AllGiftCards.OrderBy(p => p.GiftCardId);
                currentStore = "All stores";
            }
            else
            {
                giftCards = _giftCardRepository.AllGiftCards.Where(p => p.Store.Name == store)
                     .OrderBy(p => p.GiftCardId);
                currentStore = _storeRepository.AllStores.FirstOrDefault(c => c.Name == store)?.Name;
            }

            return View(new GiftCardListViewModel(giftCards, currentStore));
        }

        /*
        public IActionResult Details(int id)
		{
			var giftCard = _giftCardRepository.GetGiftCardById(id);
			if (giftCard == null)
			{
				return NotFound();
			}
			return View(giftCard);
		}
		
		public ViewResult List(int id)
		{
			IEnumerable<GiftCard> giftCards;

			if (string.IsNullOrEmpty(category))
			{
				giftCards = _giftCardRepository.AllGiftCards.OrderBy(p => p.GiftCardId);
			//	currentCategory = "All pies";
			}
			else
			{
				giftCards = _giftCardRepository.AllGiftCards.Where(p => p.Category.CategoryName == category)
					 .OrderBy(p => p.GiftCardId);
			   //currentCategory = _categoryRepository.AllCategories.FirstOrDefault(c => c.CategoryName == category)?.CategoryName;
			}

			return View(new GiftCardListViewModel(giftCards));
		}
		*/

    }
}
