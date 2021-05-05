using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductDb.DataClasses
{
    public class ShoppingCart
    {
        public ShoppingCart(string id)
        {
            Id = id;
        }

        public ShoppingCart()
        {

        }

        public string Id { get; set; }
        public List<ShoppingCartItem> Items { get; set; } = new List<ShoppingCartItem>();
    }
}
