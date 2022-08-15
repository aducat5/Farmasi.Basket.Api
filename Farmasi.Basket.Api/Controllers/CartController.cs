using Farmasi.Basket.Data.Services;
using Farmasi.Basket.Model;
using Microsoft.AspNetCore.Mvc;

namespace Farmasi.Basket.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CartController : ControllerBase
    {
        private readonly CartService _cartService;

        public CartController(CartService cartService)
        {
            _cartService = cartService;
        }

        [HttpGet("get-all")]
        public ActionResult<IEnumerable<Product>> GetAll()
        {
            var carts = _cartService.GetAll();
            return Ok(carts);
        }
        [HttpGet("get-cart")]
        public async Task<ActionResult<IEnumerable<Product>>> GetCart(string userId)
        {
            var cart = await _cartService.GetCartAsync(userId);
            return Ok(cart);
        }

        [HttpPost("add-to-cart")]
        public async Task<ActionResult> AddToCart(Product product, string userId)
        {
            await _cartService.AddToCartAsync(product, userId);
            return Ok();
        }

        [HttpPost("remove-from-cart")]
        public async Task<ActionResult> RemoveFromCart(Product product, string userId)
        {
            await _cartService.AddToCartAsync(product, userId);
            return Ok();
        }
    }
}