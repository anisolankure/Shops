using System;
using System.Collections.Generic;
using Shops.Core.Modules;

namespace Shops.Data.Helper
{
    public static class TestDataBase
    {
        public static IList<Shop> TestShops()
        {
            var listOfShops = new List<Shop>
            {
                new Shop() {Id = 1, Name = "Shakti"},
                new Shop() {Id = 2, Name = "Falcon"},
                new Shop() {Id = 3, Name = "AsianStore"},
                new Shop() {Id = 4, Name = "Popat"}
            };
            return listOfShops;
        }

        public static IList<Item> TestItems()
        {
            return new List<Item>()
            {
                new Item() { Id = 1, ShopId = 1, ExpiryDateTime = DateTime.MaxValue, Name = "Methi", Type = "Bhaji"},
                new Item() { Id = 2, ShopId = 4, ExpiryDateTime = DateTime.MaxValue, Name = "Kulfi", Type = "IceCream"},
                new Item() { Id = 3, ShopId = 2, ExpiryDateTime = DateTime.MaxValue, Name = "ParleG", Type = "Biscuits"},
                new Item() { Id = 4, ShopId = 1, ExpiryDateTime = DateTime.MaxValue, Name = "Idli", Type = "ReadyToEat"}
            };
        }

        public static IList<Shop> TestShopsWithItems()
        {
            var listOfShops = new List<Shop>
            {
                new Shop() {Id = 1, Name = "Shakti", Items = TestItems()},
                new Shop() {Id = 2, Name = "Falcon", Items = TestItems()},
                new Shop() {Id = 3, Name = "AsianStore", Items = TestItems()},
                new Shop() {Id = 4, Name = "Popat", Items = TestItems()}
            };
            return listOfShops;
        }
    }
}
