using Moq;
using NUnit.Framework;
using Shops.Core;

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
        public void GetAllItems()
        {
            _unitOfWorkMock.Setup(x => x.Items.GetAllItems()).Returns()
            Assert.Pass();
        }
    }
}