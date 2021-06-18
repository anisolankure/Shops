using System.Collections.Generic;
using System.Threading.Tasks;
using Shops.Core;
using Shops.Core.Modules;
using Shops.Core.Services;

namespace Shops.Services
{
    public class ShopService : IShopService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ShopService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<IEnumerable<Shop>> GetAllShops()
        {
            return _unitOfWork.Shops.GetAllShopsWithItems();
        }
    }
}
