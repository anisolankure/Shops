using Microsoft.EntityFrameworkCore;
using Shops.Core.Modules;
using Shops.Data.Helper;
using Shops.DataAccess.Extensions;

namespace Shops.DataAccess
{
    public class ShopsDbContext : DbContext
    {
        protected DbContext Context { get; set; }

        public ShopsDbContext(DbContextOptions<ShopsDbContext> options) : base(options)
        {
        }

        public DbSet<Shop> Shops { get; set; }
        public DbSet<Item> Items { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.SeedData();
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
            base.OnConfiguring(optionsBuilder);
        }
    }
}