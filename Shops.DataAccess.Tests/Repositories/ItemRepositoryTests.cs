using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using Shops.DataAccess.Repositories;

namespace Shops.DataAccess.Tests.Repositories
{
    [TestFixture]
    public class ItemRepositoryTests
    {
        private ItemRepository _itemRepository;

        [SetUp]
        public async Task SetUp()
        {
            var options = new DbContextOptionsBuilder<ShopsDbContext>().UseInMemoryDatabase("Shops").Options;
            var context = new ShopsDbContext(options);
            _itemRepository = new ItemRepository(context);
            await TestData.Seed(context);
        }
        
        [Test]
        public async Task GetAllItems_ReturnsItemsCorrectly()
        {
            var items = await _itemRepository.GetAllItemsWithShop();
            Assert.AreEqual(4, items.Count());
        }
    }
}