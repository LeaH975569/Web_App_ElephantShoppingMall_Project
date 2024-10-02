using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO.Pipelines;
using A22nd.Models;

namespace A22nd.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly IStoreRepository _storeRepository;

        public SearchController(IStoreRepository storeRepository)
        {
            _storeRepository = storeRepository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_storeRepository.AllStores);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            if (!_storeRepository.AllStores.Any(p => p.StoreId == id))
                return NotFound();
            return Ok(_storeRepository.AllStores.Where(p => p.StoreId == id));
        }

        [HttpPost]
        public IActionResult SearchStores([FromBody] string searchQuery)
        {
            IEnumerable<Store> stores = new List<Store>();
            if (!string.IsNullOrEmpty(searchQuery))
            {
                stores = _storeRepository.SearchStores(searchQuery);
            }
            return new JsonResult(stores);
        }

    }
}
