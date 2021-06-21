using System.Linq;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using Shops.Core;
using Shops.Data.Helper;

namespace Shops.Services.Tests
{
    [TestFixture]
    public class ItemServiceTests
    {
        private Mock<IUnitOfWork> _unitOfWorkMock;
        private ItemService _sut;
        [SetUp]
        public void Setup()
        {
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            _sut = new ItemService(_unitOfWorkMock.Object);
        }

        [Test]
        public async Task GetAllItemsAsync_ReturnsAllItemsCorrectly()
        {
            _unitOfWorkMock.Setup(x => x.Items.GetAllItemsWithShop()).ReturnsAsync(TestDataBase.TestItems);
            var result = await _sut.GetAllItemsAsync();
            Assert.IsNotNull(result);
            Assert.AreEqual(4, result.Count());
        }

        [Test]
        public async Task GetItemByIdAsync_ReturnsExpectedItemsCorrectly()
        {
            var expectedResult = TestDataBase.TestItems().SingleOrDefault(x => x.Id == 1);
            _unitOfWorkMock.Setup(x => x.Items.GetByIdAsync(1)).ReturnsAsync(expectedResult);
            var result = await _sut.GetItemByIdAsync(1);
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Id);
        }
    }
}