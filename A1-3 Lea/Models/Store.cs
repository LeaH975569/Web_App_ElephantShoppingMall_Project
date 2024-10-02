using System.ComponentModel.DataAnnotations;
using System.IO.Pipelines;

namespace A22nd.Models
{
    public class Store
    {
        [Key]
        public int StoreId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? LongDescription { get; set; }
        public string? ImageUrl { get; set; }
        public string? ImageThumbnailUrl { get; set; }
        public int CategoryId { get; set; }

        public Category Category { get; set; } = default!;
        public List<GiftCard>? GiftCards { get; set; }
    }
}
