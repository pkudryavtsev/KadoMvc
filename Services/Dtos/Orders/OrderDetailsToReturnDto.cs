using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Dtos.Orders
{
    public class OrderDetailsToReturnDto
    {
        public string OrderId { get; set; }
        public List<OrderItemDto> OrderItems { get; set; }
        public DateTimeOffset OrderDate { get; set; }
    }
}
