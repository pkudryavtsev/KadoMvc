using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Dtos.Orders
{
    public class OrdersForUserDto
    {
        public DateTimeOffset OrderDate { get; set; }
        public List<OrderBoxDto> Boxes { get; set; }
        public double Total { get; set; }
    }
}
