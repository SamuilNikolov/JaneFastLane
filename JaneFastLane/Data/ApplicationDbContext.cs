using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using JaneFastLane.Models;

namespace JaneFastLane.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<JaneFastLane.Models.Order> Order { get; set; }

        public DbSet<JaneFastLane.Models.Category> Category { get; set; }

        public DbSet<JaneFastLane.Models.Menu> Menu { get; set; }

        public DbSet<JaneFastLane.Models.Table> Table { get; set; }

        public DbSet<JaneFastLane.Models.ApplicationUser> ApplicationUser { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ApplicationUser>().HasMany(u => u.TablesWaiter);
            builder.Entity<ApplicationUser>().HasOne(u => u.TableCustomer);
            builder.Entity<Table>().HasOne(u => u.Waiter);
            builder.Entity<Table>().HasMany(u => u.Customers);

            base.OnModelCreating(builder);
        }
    }
}