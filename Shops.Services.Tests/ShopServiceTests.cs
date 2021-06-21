using System.Linq;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using Shops.Core;
using Shops.Data.Helper;

namespace Shops.Services.Tests
{
    [TestFixture]
    public class ShopServiceTests
    {
        private Mock<IUnitOfWork> _unitOfWorkMock;
        private ShopService _sut;
        [SetUp]
        public void Setup()
        {
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            _sut = new ShopService(_unitOfWorkMock.Object);
        }

        [Test]
        public async Task GetAllItemsAsync_ReturnsAllItemsCorrectly()
        {
            var expectedResult = TestDataBase.TestShopsWithItems();
            _unitOfWorkMock.Setup(x => x.Shops.GetAllAsync()).ReturnsAsync(expectedResult);
            var result = await _sut.GetAllShopsAsync();
            Assert.IsNotNull(result);
            Assert.AreEqual(4, result.Count());
        }
    }
}