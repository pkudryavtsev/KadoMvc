using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Dtos.Orders
{
    public class OrderItemDto
    {
        public string BoxName { get; set; }
        public List<string> ProductNames { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
