using System.IO.Pipelines;
using A22nd.Models;

namespace A22nd.Models
{
    public class MockGiftCardRepository : IGiftCardRepository
    {

        private readonly IStoreRepository _storeRepository = new MockStoreRepository();

        public IEnumerable<GiftCard> AllGiftCards => new List<GiftCard>
        {
            new GiftCard { GiftCardId = 1, GiftCardPrice = 10, GiftCardDescription = "" },
            new GiftCard { GiftCardId = 2, GiftCardPrice = 15, GiftCardDescription = "" },
            new GiftCard { GiftCardId = 3, GiftCardPrice = 20, GiftCardDescription = "" },
            new GiftCard { GiftCardId = 4, GiftCardPrice = 25, GiftCardDescription = "" },
            new GiftCard { GiftCardId = 5, GiftCardPrice = 30, GiftCardDescription = "" },
            new GiftCard { GiftCardId = 6, GiftCardPrice = 35, GiftCardDescription = "" }
        };

        public GiftCard? GetGiftCardById(int giftCardId) => AllGiftCards.FirstOrDefault(p => p.GiftCardId == giftCardId);
    }

}

