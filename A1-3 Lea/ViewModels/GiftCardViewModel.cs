using A22nd.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace A22nd.ViewModels
{
    public class GiftCardViewModel
    {
        [BindNever]
        public IEnumerable<GiftCard> GiftCards { get; set; }
        public IEnumerable<Store> Stores { get; set; }
        public string? CurrentStore { get; set; } 
        public int SelectedGiftCardId { get; set; } 
        public int SelectedStoreId { get; set; }
        public string? GiftCardDescription { get; set; }
    }
}
