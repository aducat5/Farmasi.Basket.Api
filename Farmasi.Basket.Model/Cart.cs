using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farmasi.Basket.Model
{
    public record Cart
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public List<Product> Products { get; set; }
    }
}
