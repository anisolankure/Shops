using System.Collections.Generic;
using System.Threading.Tasks;
using Shops.Core;
using Shops.Core.Modules;
using Shops.Core.Services;

namespace Shops.Services
{
    public class ItemService : IItemService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ItemService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<IEnumerable<Item>> GetAllItems()
        {
            return _unitOfWork.Items.GetAllItems();
        }
    }
}
