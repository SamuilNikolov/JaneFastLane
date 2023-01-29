using Jane_Fast_Lane.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Jane_Fast_Lane.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }


        public DbSet<Jane_Fast_Lane.Models.Order> Order { get; set; }

        public DbSet<Jane_Fast_Lane.Models.Category> Category { get; set; }

        public DbSet<Jane_Fast_Lane.Models.Menu> Menu { get; set; }

        public DbSet<Jane_Fast_Lane.Models.Table> Table { get; set; }
    }
}