using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using Shops.DataAccess.Repositories;
using Shops.Tests.Helper;

namespace Shops.DataAccess.Tests.Repositories
{
    [TestFixture]
    public class ShopRepositoryTests
    {
        private ShopRepository _itemRepository;

        [SetUp]
        public async Task SetUp()
        {
            var options = new DbContextOptionsBuilder<ShopsDbContext>().UseInMemoryDatabase("Shops").Options;
            var context = new ShopsDbContext(options);
            _itemRepository = new ShopRepository(context);
            
            await TestDataBase.InitialSetUp(context);
        }

        [Test]
        public async Task GetAllItems_ReturnsItemsCorrectly()
        {
            var items = await _itemRepository.GetAllShopsWithItems();
            var enumerable = items.ToList();
            bool result = false;
            foreach (var shop in enumerable)
            {
                if (shop.Items != null)
                {
                    result = true;
                }
            }
            Assert.IsTrue(result);
            Assert.IsNotEmpty(enumerable);
        }
    }
}