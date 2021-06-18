using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using Shops.DataAccess.Repositories;
using Shops.Tests.Helper;

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
            
            await TestDataBase.InitialSetUp(context);
        }

        [Test]
        public async Task GetAllItems_ReturnsItemsCorrectly()
        {
            var items = await _itemRepository.GetAllItems();
            Assert.IsNotEmpty(items);
        }
    }
}