using Microsoft.EntityFrameworkCore;
using Shops.Core.Modules;
using Shops.Data.Helper;

namespace Shops.DataAccess.Extensions
{
    public static class ModelBuilderExtension
    {
        public static void SeedData(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Shop>().HasData(TestDataBase.TestShops());
            modelBuilder.Entity<Item>().HasData(TestDataBase.TestItems());
        }
    }
}