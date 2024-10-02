using A22nd.ViewModels;
using Microsoft.AspNetCore.Mvc;
using A22nd.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace A22nd.Controllers
{
    public class StoreController : Controller
    {

        private readonly IStoreRepository _storeRepository;
        private readonly ICategoryRepository _categoryRepository;
        public StoreController(IStoreRepository storeRepository, ICategoryRepository categoryRepository)
        {
            _storeRepository = storeRepository;
            _categoryRepository = categoryRepository;
        }


        public ViewResult List(string category, string sortOrder)
        {
            ViewBag.NameSortParam = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.CategorySortParam = sortOrder == "category" ? "category_desc" : "category";

            IEnumerable<Store> stores;
            string? currentCategory;

            if (string.IsNullOrEmpty(category))
            {
                stores = _storeRepository.AllStores;
                currentCategory = "All stores";
            }
            else
            {
                stores = _storeRepository.AllStores.Where(p => p.Category.CategoryName == category);
                currentCategory = _categoryRepository.AllCategories.FirstOrDefault(c => c.CategoryName == category)?.CategoryName;
            }

            switch (sortOrder)
            {
                case "name_desc":
                    stores = stores.OrderByDescending(s => s.Name);
                    break;
                case "category":
                    stores = stores.OrderBy(s => s.Category.CategoryName);
                    break;
                case "category_desc":
                    stores = stores.OrderByDescending(s => s.Category.CategoryName);
                    break;
                default:
                    stores = stores.OrderBy(s => s.Name);
                    break;
            }

            return View(new StoreListViewModel(stores, currentCategory));
        }

        public IActionResult Details(int id)
        {
            var store = _storeRepository.GetStoreById(id);
            if (store == null)
            {
                return NotFound();
            }
            return View(store);
        }

        public IActionResult Search()
        {
            return View();
        }

        [Authorize]
        public IActionResult Create()
        {
            var categories = _categoryRepository.AllCategories.ToList();
            ViewBag.Categories = new SelectList(categories, "CategoryId", "CategoryName");
            return View();
        }

        [HttpPost]
        [Authorize]
        public IActionResult Create(Store store)
        {
            store.Category = _categoryRepository.FindById(store.CategoryId);
            try
            {
                _storeRepository.Create(store);
                return RedirectToAction("List");
            }
            catch
            {
                return View(store);
            }


        }

        [Authorize]
        public IActionResult Edit(int id)
        {
            var store = _storeRepository.GetStoreById(id);
            if (store == null)
            {
                return NotFound();
            }

            var categories = _categoryRepository.AllCategories.ToList();
            ViewBag.Categories = new SelectList(categories, "CategoryId", "CategoryName");

            return View(store);
        }

        [HttpPost]
        [Authorize]
        public IActionResult Edit(Store store)
        {
            if (store == null)
            {
                return NotFound();
            }

            try
            {
                _storeRepository.Update(store);
                return RedirectToAction("List");
            }
            catch
            {
                return View(store);
            }
        }

        [Authorize]
        public IActionResult Delete(int id)
        {
            var store = _storeRepository.GetStoreById(id);
            if (store == null)
            {
                return NotFound();
            }
            return View(store);
        }

        [HttpPost, ActionName("Delete")]
        [Authorize]
        public IActionResult DeleteConfirmed(int id)
        {
            if (id != null)
            {
                _storeRepository.Delete(id);
                return RedirectToAction("List");
            }
            return View();

        }
    }
}