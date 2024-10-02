using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace A22nd.Models
{
    public class GiftCard
    {
        [BindNever]
        public int GiftCardId { get; set; }
        public string? GiftCardDescription { get; set; }
        public decimal GiftCardPrice { get; set; }
        public int? StoreId { get; set; }

        [BindProperty]
        public Store Store { get; set; } = default!;

    }
}
