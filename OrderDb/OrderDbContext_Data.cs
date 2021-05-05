using Microsoft.EntityFrameworkCore;
using OrderDb.DataClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDb
{
    public partial class OrderDbContext
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<OrderProduct> OrderProducts{ get; set; }
    }
}
