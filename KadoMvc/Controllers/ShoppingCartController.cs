using Microsoft.AspNetCore.Mvc;
using ProductDb.DataClasses;
using Services;
using Services.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KadoMvc.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShoppingCartController : ControllerBase
    {
        private readonly ShoppingCartService _shoppingCartService;

        public ShoppingCartController(ShoppingCartService shoppingCartService)
        {
            _shoppingCartService = shoppingCartService;
        }

        [HttpGet]
        public async Task<ActionResult<ShoppingCart>> GetBasketById(string id)
        {
            var shoppingCart = await _shoppingCartService.GetShoppingCartAsync(id);

            return Ok(shoppingCart ?? new ShoppingCart(id));
        }

        [HttpPost]
        public async Task<ActionResult<ShoppingCart>> UpdateShoppingCart(ShoppingCartDto shoppingCart)
        {
            var updatedShoppingCart= await _shoppingCartService.UpdateShoppingCartAsync(shoppingCart);

            return Ok(updatedShoppingCart);
        }

        [HttpDelete]
        public async Task DeleteShoppingCart(string id)
        {
            await _shoppingCartService.DeleteShoppingCartAsync(id);
        }
    }
}
