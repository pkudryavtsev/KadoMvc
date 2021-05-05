using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Dtos.Orders
{
    public class OrderBoxDto
    {
        public int Id { get; set; }
        public string BoxName { get; set; }
        public double Price { get; set; }
    }
}
