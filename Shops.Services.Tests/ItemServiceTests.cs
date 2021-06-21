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
        public async Task GetAllItems()
        {
            _unitOfWorkMock.Setup(x => x.Items.GetAllItems()).ReturnsAsync(TestDataBase.TestItems);
            var result = await _sut.GetAllItemsAsync();
            Assert.IsNotNull(result);
            Assert.AreEqual(4, result.Count());
        }
    }
}