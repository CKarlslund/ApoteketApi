using Apoteket.Domain.Orders;
using Microsoft.EntityFrameworkCore;

namespace Apoteket.Infrastructure.Persistence
{
    public class OrderRepository : IOrderRepository
    {
        private readonly OrderDbContext _context;

        public OrderRepository(OrderDbContext context) 
        {
            _context = context;
        }

        public async Task<Order> Add(Order order)
        {
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();

            return order;
        }
    }
}
