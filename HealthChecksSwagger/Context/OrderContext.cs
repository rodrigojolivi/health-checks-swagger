using HealthChecksSwagger.Model;
using Microsoft.EntityFrameworkCore;

namespace HealthChecksSwagger.Context
{
    public class OrderContext : DbContext
    {
        public OrderContext(DbContextOptions<OrderContext> options)
            : base(options)
        {
        }

        public DbSet<Order> Order { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>()
                .HasKey(x => x.IdOrder);

            base.OnModelCreating(modelBuilder);
        }
    }
}
