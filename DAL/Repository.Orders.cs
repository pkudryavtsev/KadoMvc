using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderDb.DataClasses;
using Microsoft.EntityFrameworkCore;


namespace DAL.Repository.Orders
{
    public static class RepositoryOrders
    {
        public static async Task<IReadOnlyList<Order>> GetOrdersForUser(this Repo repo, string email)
        {
            return await repo.OrderContext.Orders
                                                .Where(o => o.UserEmail == email)
                                                .Include(o => o.OrderItems)
                                                    .ThenInclude(oi => oi.OrderProducts)
                                                .ToListAsync();
        }

        public static async Task<Order> GetOrderById(this Repo repo, int id)
        {
            return await repo.OrderContext.Orders
                                          .Include(o => o.OrderItems)
                                            .ThenInclude(oi => oi.OrderProducts)
                                          .FirstOrDefaultAsync(o => o.Id == id);
        }

        public static async Task<bool> CreateOrder(this Repo repo, Order order)
        {
            await repo.OrderContext.AddAsync(order);

            var changes = repo.OrderContext.SaveChanges();
            return changes > 0;
        }
    }
}
