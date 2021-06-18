using System.Collections.Generic;
using System.Threading.Tasks;
using Shops.Core.Modules;

namespace Shops.Core.Repositories
{
    public interface IShopRepository : IRepository<Shop>
    {
        Task<IEnumerable<Shop>> GetAllShopsWithItems();
    }
}