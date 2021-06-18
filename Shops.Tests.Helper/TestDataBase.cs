using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Shops.Core.Modules;
using Shops.DataAccess;

namespace Shops.Tests.Helper
{
    public static class TestDataBase
    {
        public static async Task InitialSetUp(ShopsDbContext indianShopsDbContext)
        {
            await indianShopsDbContext.Database.EnsureDeletedAsync();
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
            await indianShopsDbContext.Shops.AddRangeAsync(listOfShops);
            await indianShopsDbContext.Items.AddRangeAsync(listOfItems);
            await indianShopsDbContext.SaveChangesAsync();
        }
    }
}
