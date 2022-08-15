using Redis.OM.Modeling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farmasi.Basket.Model
{

    [Document(StorageType = StorageType.Json, Prefixes = new[] { "Cart" })]
    public class Cart
    {
        // Id Field, also indexed, marked as nullable to pass validation
        [RedisIdField][Indexed] public string? Id { get; set; }

        // Indexed for exact text matching
        [Indexed] public string? UserIdentifier { get; set; }


        [Indexed] public List<Product> Products { get; set; } = new List<Product>();

    }
}
