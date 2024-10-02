using Microsoft.EntityFrameworkCore;
using System.IO.Pipelines;

namespace A22nd.Models
{
    public class GiftCardRepository : IGiftCardRepository
    {
        private readonly MallStoreDbContext _mallStoreDbContext;

        public IEnumerable<GiftCard> AllGiftCards
        {
            get
            {
                return _mallStoreDbContext.GiftCards.Include(c => c.Store);
            }

        }


        public GiftCardRepository(MallStoreDbContext mallStoreDbContext)
        {
            _mallStoreDbContext = mallStoreDbContext;
        }
        public GiftCard? GetGiftCardById(int giftCardId)
        {
            return _mallStoreDbContext.GiftCards.FirstOrDefault(s => s.GiftCardId == giftCardId);
        }

        


   //     public IEnumerable<GiftCard> AllGiftCardPrice => _mallStoreDbContext.GiftCards.OrderBy(p => p.GiftCardPrice);

    }
}
