using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.IO.Pipelines;

namespace A22nd.Models
{
    public class ShoppingCartItem
    {
        [BindNever]
        public int ShoppingCartItemId { get; set; }
        public GiftCard GiftCard { get; set; } = default!;
        public int Amount { get; set; }
        public string ShoppingCartId { get; set; } = default!;
        public Store SelectedStore { get; set; } = default!;
    }
}
