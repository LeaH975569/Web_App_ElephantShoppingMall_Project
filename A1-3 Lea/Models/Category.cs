namespace A22nd.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = string.Empty;
        public List<Store>? Stores { get; set; }
    }
}
