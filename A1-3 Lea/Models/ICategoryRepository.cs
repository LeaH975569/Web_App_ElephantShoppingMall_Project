namespace A22nd.Models
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> AllCategories { get; }
        Category FindById(int categoryId);
    }
}
