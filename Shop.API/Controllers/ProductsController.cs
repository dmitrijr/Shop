using Microsoft.AspNetCore.Mvc;
using Shop.Entities;
using Shop.Services;
using Shop.Services.Models;

namespace Shop.API.Controllers
{
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService productService;

        public ProductsController(IProductService productService)
        {
            this.productService = productService;
        }

        [HttpGet]
        public ActionResult<List<Product>> GetAll(int page, int itemsPerPage)
        {
            return productService.Get(page, itemsPerPage);
        }

        [HttpGet("{id}")]
        public ActionResult<Product> Get(int id)
        {
            return productService.Get(id);
        }

        [HttpPost]
        public ActionResult<int> Create(CreateProduct product)
        {
            return productService.Create(product);
        }
    }
}