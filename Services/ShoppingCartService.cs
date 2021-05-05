using AutoMapper;
using ProductDb.DataClasses;
using Services.Dtos;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Services
{
    public class ShoppingCartService
    {
        private readonly IDatabase _database;
        private readonly IMapper _mapper;

        public ShoppingCartService(IConnectionMultiplexer redis, IMapper mapper)
        {
            _database = redis.GetDatabase();
            _mapper = mapper;
        }

        public async Task<bool> DeleteShoppingCartAsync(string basketId)
        {
            return await _database.KeyDeleteAsync(basketId);
        }

        public async Task<ShoppingCart> GetShoppingCartAsync(string shoppingCartId)
        {
            var data = await _database.StringGetAsync(shoppingCartId);

            return data.IsNullOrEmpty ? null : JsonSerializer.Deserialize<ShoppingCart>(data);
        }

        public async Task<ShoppingCart> UpdateShoppingCartAsync(ShoppingCartDto shoppingCartToUpdate)
        { 
            var shoppingCart = _mapper.Map<ShoppingCartDto, ShoppingCart>(shoppingCartToUpdate);
            var created = await _database.StringSetAsync(shoppingCartToUpdate.Id, JsonSerializer.Serialize(shoppingCartToUpdate), TimeSpan.FromDays(30));

            if (!created) return null;
            return await GetShoppingCartAsync(shoppingCartToUpdate.Id);
        }
    }
}
