using System.Collections.Generic;
using System.Threading.Tasks;
using Shops.Core.Modules;

namespace Shops.Core.Repositories
{
    public interface IItemRepository : IRepository<Item>
    {
        Task<IEnumerable<Item>> GetAllItemsWithShop();
    }
}