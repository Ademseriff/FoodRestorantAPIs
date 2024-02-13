using Microsoft.EntityFrameworkCore;

namespace OrderApi.Models.Contexts
{
    public class OrderApiDbContext : DbContext
    {
        public OrderApiDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<OrderAdd> orderAdds { get; set; }

        public DbSet<OrderDetails> orderDetails { get; set; }
    }
}
