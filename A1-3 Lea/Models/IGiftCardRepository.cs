namespace A22nd.Models
{
    public interface IGiftCardRepository
    {
        IEnumerable<GiftCard> AllGiftCards { get; }
    //    IEnumerable<GiftCard> AllGiftCardPrice { get; }
        GiftCard? GetGiftCardById(int giftCardId);
    }
}
