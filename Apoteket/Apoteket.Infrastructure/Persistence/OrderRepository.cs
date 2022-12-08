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

        public async Task<Order> GetAsync(int id)
        {
            return await _context.Orders.FirstOrDefaultAsync(o => o.Id == id);
        }

        public async Task<IEnumerable<Order>> GetAsync()
        {
            return await _context.Orders.ToListAsync();
        }

        public async Task<Order> CreateAsync(Order order)
        {
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();

            return order;
        }

        public async Task<Order> UpdateAsync(Order order)
        {
            _context.Orders.Update(order);
            await _context.SaveChangesAsync();

            return order;
        }

        public async Task<IEnumerable<Order>> DeleteAsync()
        {
            var orders = await _context.Orders.ToListAsync();

            foreach (var order in orders)
            {
                _context.Orders.Remove(order);
            }

            await _context.SaveChangesAsync();
            return orders;
        }
    }
}
