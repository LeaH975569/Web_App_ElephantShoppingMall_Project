namespace A22nd.Models
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly MallStoreDbContext _mallStoreDbContext;
        //Press Alt+Enter to generate the constructor
        public CategoryRepository(MallStoreDbContext mallStoreDbContext)
        {
            _mallStoreDbContext = mallStoreDbContext;
        }

        public IEnumerable<Category> AllCategories => _mallStoreDbContext.Categories.OrderBy(p => p.CategoryName);

        public Category FindById(int categoryId)
        {
            return _mallStoreDbContext.Categories.FirstOrDefault(c => c.CategoryId == categoryId);
        }
    }
}
