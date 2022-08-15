using Farmasi.Basket.Model;
using MongoDB.Bson;
using MongoDB.Driver;
using Redis.OM;
using Redis.OM.Searching;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Farmasi.Basket.Data.Services
{
    public class CartService
    {
        private readonly RedisConnectionProvider _provider;
        private readonly RedisCollection<Cart> _carts;
        public CartService(RedisConnectionProvider provider)
        {
            _provider = provider;
            _carts = (RedisCollection<Cart>)provider.RedisCollection<Cart>();
        }


        public async Task AddToCartAsync(Product product, string userId)
        {
            //check basket, create if not exist
            try
            {

                var cart = _carts.Where(c => c.UserIdentifier == userId).FirstOrDefault();

                if (cart == null) await _carts.InsertAsync(new()
                {
                    Products = new(),
                    UserIdentifier = userId
                });

                cart = _carts.Where(c => c.UserIdentifier == userId).FirstOrDefault();
                cart!.Products.Add(product);

                await _carts.UpdateAsync(cart);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
