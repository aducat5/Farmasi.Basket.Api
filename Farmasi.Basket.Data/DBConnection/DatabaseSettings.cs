using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farmasi.Basket.Data
{
    public class DatabaseSettings : IDatabaseSettings
    {
        public string ConnectionString { get; set; } = "";
        public string DatabaseName { get; set; } = "";
        public string CollectionName { get; set; } = "";
    }
}
