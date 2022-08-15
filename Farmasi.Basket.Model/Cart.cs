using Redis.OM.Modeling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farmasi.Basket.Model
{

    [Document(StorageType = StorageType.Json, Prefixes = new[] { "Cart" })]
    public record Cart
    {

        [RedisIdField]
        [Indexed] 
        public string? Id { get; set; }

        [Indexed]
        [Searchable]
        public string UserId { get; set; } = "";
        
        public List<Product> Products { get; set; } = new List<Product>();
    }
}
