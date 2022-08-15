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

        
        public async Task<Cart> GetCartAsync(string userId) => await _carts.Where(c => c.UserIdentifier == userId).FirstOrDefaultAsync();
        public RedisCollection<Cart> GetAll() => _carts;

        public async Task AddToCartAsync(Product product, string userId)
        {
            //check basket, create if not exist

            var cart = await _carts.Where(c => c.UserIdentifier == userId).FirstOrDefaultAsync();

            if (cart == null) await _carts.InsertAsync(new()
            {
                Products = new(),
                UserIdentifier = userId
            });

            cart = await _carts.Where(c => c.UserIdentifier == userId).FirstOrDefaultAsync();

            cart!.Products.Add(product);

            _carts.Update(cart);
        }
        public async Task RemoveFromCartAsync(string productId, string userId)
        {
            var cart = await _carts.Where(c => c.UserIdentifier == userId).FirstOrDefaultAsync();

            if (cart == null) return;

            var product = cart.Products.Where(p => p.Id == productId).FirstOrDefault();
            if (product == null) return;

            cart.Products.Remove(product);

            _carts.Update(cart);
        }
    }
}
