using Farmasi.Basket.Model;
using Microsoft.AspNetCore.Mvc;

namespace Farmasi.Basket.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;

        public ProductController(ILogger<ProductController> logger)
        {
            _logger = logger;
        }

        [HttpGet("get-all")]
        public async Task<ActionResult<IEnumerable<Product>>> GetAll()
        {
            var warehouses = await _warehouseService.GetAllAsync();
            var response = new ResponseModel()
            {
                Data = warehouses,
                RequestCount = _requestHandler.RequestCount
            };
            return Ok(response);
        }

    }
}