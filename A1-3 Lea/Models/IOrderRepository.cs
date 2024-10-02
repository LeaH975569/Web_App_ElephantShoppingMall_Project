namespace A22nd.Models
{
    public interface IOrderRepository
    {
        void CreateOrder(Order order, int selectedGiftCardId, int selectedStoreId);

    }
}
