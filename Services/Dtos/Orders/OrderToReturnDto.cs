using OrderDb.DataClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Dtos.Orders
{
    public class OrderToReturnDto
    {
        public int Id { get; set; }
        public DateTimeOffset OrderDate { get; set; } = DateTimeOffset.Now;
        public Address UserAddress { get; set; }
        public IReadOnlyList<OrderItemDto> OrderItems { get; set; }
        public string Status { get; set; }
        public decimal Total { get; set; }
    }
}
