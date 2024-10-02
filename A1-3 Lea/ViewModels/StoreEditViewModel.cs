using A22nd.Models;
using Microsoft.AspNetCore.Mvc;

namespace A22nd.ViewModels
{
    public class StoreEditViewModel
    {
        [BindProperty]
        public Store Store { get; set; } = default!;
        public IEnumerable<Category> Categories { get; set; }


    }
}
