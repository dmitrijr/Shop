using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shop.Entities;
using Shop.Services;
using Shop.Services.Models;

namespace Shop.API.Controllers
{

    [Authorize]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService productService;

        public ProductsController(IProductService productService)
        {
            this.productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetAllAsync(int page, int itemsPerPage)
        {
            return await productService.GetAsync(page, itemsPerPage);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var product = productService.Get(id);
            if (product == null)
                return NotFound();

            return Ok(product);
        }

        [HttpPost]
        public IActionResult Create(CreateProduct product)
        {
            return Created("/", productService.Create(product));
        }
    }
}