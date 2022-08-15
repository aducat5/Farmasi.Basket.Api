using Farmasi.Basket.Model;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Farmasi.Basket.Data.Services
{
    public class ProductService
    {
        private readonly IMongoCollection<Product> _products;

        public ProductService(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _products = database.GetCollection<Product>(settings.CollectionName);
        }
        public async Task<List<Product>> GetAllAsync()
        {
            try
            {

                return await _products.Find(p => p.IsDeleted == false).ToListAsync();
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public async Task<Product> GetProduct(string productId)
        {
            return await _products.Find(w => w.Id == productId).FirstOrDefaultAsync();
        }
        public async Task AddProduct(Product newProduct)
        {
            await _products.InsertOneAsync(newProduct);
            //
        }
    }
}
