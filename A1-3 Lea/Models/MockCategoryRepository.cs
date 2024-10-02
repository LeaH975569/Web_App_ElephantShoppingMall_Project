using System.ComponentModel.Design;

namespace A22nd.Models
{
    public class MockCategoryRepository : ICategoryRepository
    {
        public IEnumerable<Category> AllCategories =>
            new List<Category>
            {
                new Category{CategoryId= 1,CategoryName="Cosmetics"},
                new Category{CategoryId= 2,CategoryName="Designer Luxury"},
                new Category{CategoryId= 3,CategoryName="Food Court"},
                new Category{CategoryId= 4,CategoryName="Beauty"},
                new Category{CategoryId= 5,CategoryName="Banks"},
                new Category{CategoryId= 6,CategoryName="Homeware"}
            };

        public Category FindById(int categoryId)
        {
            return AllCategories.FirstOrDefault(c => c.CategoryId == categoryId);
        }
    }

}