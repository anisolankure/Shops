using System.Collections.Generic;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using Shops.Core;
using Shops.Core.Modules;

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
            _unitOfWorkMock.Setup(x => x.Items.GetAllItems()).ReturnsAsync(It.IsAny<List<Item>>());
            var result = Task.Run(async() => await _sut.GetAllItems());
            Assert.IsNotNull(result);
        }
    }
}