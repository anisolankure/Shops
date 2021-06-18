using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Shops.Core.Modules;

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
            var listOfShops = new List<Shop>
            {
                new Shop() {Id = 1, Name = "Shakti"},
                new Shop() {Id = 2, Name = "Falcon"},
                new Shop() {Id = 3, Name = "AsianStore"},
                new Shop() {Id = 4, Name = "Popat"}
            };
            var listOfItems = new List<Item>()
            {
                new Item() { Id = 1, ShopId = 1, ExpiryDateTime = DateTime.MaxValue, Name = "Methi", Type = "Bhaji"},
                new Item() { Id = 2, ShopId = 4, ExpiryDateTime = DateTime.MaxValue, Name = "Kulfi", Type = "IceCream"},
                new Item() { Id = 3, ShopId = 2, ExpiryDateTime = DateTime.MaxValue, Name = "ParleG", Type = "Biscuits"},
                new Item() { Id = 4, ShopId = 1, ExpiryDateTime = DateTime.MaxValue, Name = "Idli", Type = "ReadyToEat"}
            };
            modelBuilder.Entity<Shop>().HasData(
                listOfShops);
            modelBuilder.Entity<Item>().HasData(
                listOfItems);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
            base.OnConfiguring(optionsBuilder);
        }
    }
}