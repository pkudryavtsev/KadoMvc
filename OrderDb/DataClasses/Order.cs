using IdentityDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDb.DataClasses
{
    public class Order
    {
        public int Id { get; set; }
        public string UserEmail { get; set; }
        public DateTimeOffset OrderDate { get; set; } = DateTimeOffset.Now;
        public Address UserAddress { get; set; }
        public IReadOnlyList<OrderItem> OrderItems { get; set; }
        public OrderStatus Status { get; set; } = OrderStatus.Pending;
        public double Total { get; set; }

    }
}
