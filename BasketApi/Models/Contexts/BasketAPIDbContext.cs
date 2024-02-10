using Microsoft.EntityFrameworkCore;

namespace BasketApi.Models.Contexts
{
    public class BasketAPIDbContext : DbContext
    {
        public BasketAPIDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<BasketAdd> basketAdds { get; set; }

    }
}
