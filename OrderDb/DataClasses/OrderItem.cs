using ProductDb.DataClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDb.DataClasses
{
    public class OrderItem
    {
        public int Id { get; set; }
        public int BoxId { get; set; }
        public string BoxName { get; set; }
        public List<OrderProduct> OrderProducts { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
    }
}
