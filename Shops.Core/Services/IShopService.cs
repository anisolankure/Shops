using System.Collections.Generic;
using System.Threading.Tasks;
using Shops.Core.Modules;

namespace Shops.Core.Services
{
    public interface IShopService
    {
        Task<IEnumerable<Shop>> GetAllShops();
    }
}