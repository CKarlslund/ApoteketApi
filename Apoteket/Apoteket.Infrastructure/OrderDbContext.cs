using Microsoft.EntityFrameworkCore;

namespace Apoteket.Infrastructure
{
    public class OrderDbContext : DbContext
    {
        public OrderDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<OrderDbModel> TodoItems { get; set; } = null!;
    }
}
