namespace A22nd.Models
{
    public class OrderDetail
    {
        public int OrderDetailId { get; set; }
        public int OrderId { get; set; }
        public decimal Amount { get; set; }
        public int GiftCardId { get; set; }
        public int StoreId { get; set; }
        public Store Store { get; set; } = default!;
        public GiftCard GiftCard { get; set; } = default!;
        public Order Order { get; set; } = default!;
    }
}
