using Farmasi.Basket.Data.Services;
using Farmasi.Basket.Model;
using Microsoft.AspNetCore.Mvc;

namespace Farmasi.Basket.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ProductService _productService;

        public ProductController(ProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("get-all")]
        public async Task<ActionResult<IEnumerable<Product>>> GetAll()
        {
            var products = await _productService.GetAllAsync();
            
            return Ok(products);
        }

        [HttpPost("new-product")]
        public async Task<ActionResult> NewProduct(Product newProduct)
        {
            await _productService.AddProduct(newProduct);

            return Ok();
        }
    }
}