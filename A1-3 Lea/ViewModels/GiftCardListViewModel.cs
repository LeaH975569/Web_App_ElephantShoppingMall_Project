using A22nd.Models;
using System.IO.Pipelines;

namespace A22nd.ViewModels
{
    public class GiftCardListViewModel
    {
        public IEnumerable<GiftCard> GiftCards { get; }
		public string? CurrentStore { get; }

		public GiftCardListViewModel(IEnumerable<GiftCard> giftCards, string? currentStore)
        {
            GiftCards = giftCards;
            CurrentStore = currentStore;

		}
    }
}
