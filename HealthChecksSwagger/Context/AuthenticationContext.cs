using HealthChecksSwagger.Model;
using Microsoft.EntityFrameworkCore;

namespace HealthChecksSwagger.Context
{
    public class AuthenticationContext : DbContext
    {
        public AuthenticationContext(DbContextOptions<AuthenticationContext> options) 
            : base(options)
        {
        }

        public DbSet<User> User { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasKey(x => x.IdUser);

            base.OnModelCreating(modelBuilder);
        }
    }
}
