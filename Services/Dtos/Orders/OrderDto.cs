using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Dtos.Orders
{
    public class OrderDto
    {
        public string ShoppingCartId { get; set; }
        public AddressDto UserAddress { get; set; }
    }
}
