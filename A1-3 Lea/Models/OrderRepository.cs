namespace A22nd.Models
{
    public class OrderRepository : IOrderRepository
    {
        private readonly MallStoreDbContext _mallStoreDbContext;

        private readonly IOrderRepository _orderRepository;

        public OrderRepository(MallStoreDbContext mallStoreDbContext)
        {
            _mallStoreDbContext = mallStoreDbContext;
        }

        public void CreateOrder(Order order, int selectedGiftCardId, int selectedStoreId)
        {
            order.OrderPlaced = DateTime.Now;

            var selectedGiftCard = _mallStoreDbContext.GiftCards.FirstOrDefault(gc => gc.GiftCardId == selectedGiftCardId);
            var selectedStore = _mallStoreDbContext.Stores.FirstOrDefault(s => s.StoreId == selectedStoreId);

            if (selectedGiftCard == null || selectedStore == null)
              

            order.OrderTotal = selectedGiftCard.GiftCardPrice;
            order.OrderDetails = new List<OrderDetail>
            {
                new OrderDetail
                {
                    GiftCardId = selectedGiftCard.GiftCardId,
                    Amount = selectedGiftCard.GiftCardPrice,
                    StoreId = selectedStore.StoreId
                }
            };

            _mallStoreDbContext.Orders.Add(order);
            _mallStoreDbContext.SaveChanges();
        }


    }
}

