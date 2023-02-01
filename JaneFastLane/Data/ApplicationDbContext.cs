﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
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


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ApplicationUser>().HasMany(u => u.Table);
            builder.Entity<Table>().HasOne(u => u.Waiter);
            builder.Entity<Table>().HasOne(u => u.Customer);

            base.OnModelCreating(builder);
        }
    }
}