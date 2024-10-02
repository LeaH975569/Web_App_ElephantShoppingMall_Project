using Microsoft.AspNetCore.Mvc;

namespace A22nd.Models
{
    public interface IStoreRepository
    {
        IEnumerable<Store> AllStores { get; }
        Store? GetStoreById(int storeId);
        IEnumerable<Store> SearchStores(string searchQuery);
        void Create(Store store);
        void Update(Store store);
        void Delete(int storeId);


    }
}
