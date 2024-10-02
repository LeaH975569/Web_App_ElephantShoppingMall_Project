using Microsoft.EntityFrameworkCore;


namespace A22nd.Models
{
    public class StoreRepository : IStoreRepository
    {
        private readonly MallStoreDbContext _mallStoreDbContext;

        public StoreRepository(MallStoreDbContext mallStoreDbContext)
        {
            _mallStoreDbContext = mallStoreDbContext;
        }

        public IEnumerable<Store> AllStores => _mallStoreDbContext.Stores.Include(c => c.Category);

        public Store? GetStoreById(int storeId) => _mallStoreDbContext.Stores.FirstOrDefault(p => p.StoreId == storeId);

        public IEnumerable<Store> SearchStores(string searchQuery) => _mallStoreDbContext.Stores.Where(p => p.Name.Contains(searchQuery));

        public void Create(Store store)
        {
            _mallStoreDbContext.Stores.Add(store);
            _mallStoreDbContext.SaveChanges();
        }

        public void Update(Store store)
        {
            _mallStoreDbContext.Stores.Update(store);
            _mallStoreDbContext.SaveChanges();
        }

        public void Delete(int storeId)
        {
            var store = GetStoreById(storeId);
            if (store != null)
            {
                _mallStoreDbContext.Stores.Remove(store);
                _mallStoreDbContext.SaveChanges();
            }
        }
    }
}