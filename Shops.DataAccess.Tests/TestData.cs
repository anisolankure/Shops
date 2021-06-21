using Shops.Data.Helper;
using System.Threading.Tasks;

namespace Shops.DataAccess.Tests
{
    public static class TestData
    {
        public static async Task Seed(ShopsDbContext context)
        {
            await context.Database.EnsureDeletedAsync();
            await context.Shops.AddRangeAsync(TestDataBase.TestShops());
            await context.Items.AddRangeAsync(TestDataBase.TestItems());
            await context.SaveChangesAsync();
        }
    }
}