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
        private readonly CartService _cartService;

        public ProductController(ProductService productService, CartService cartService)
        {
            _productService = productService;
            _cartService = cartService;
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

        [HttpPost("add-to-cart")]
        public async Task<ActionResult> AddToCart(Product product, string userId)
        {
            await _cartService.AddToCartAsync(product, userId);

            return Ok();
        }
    }
}