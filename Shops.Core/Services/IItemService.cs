using System.Collections.Generic;
using System.Threading.Tasks;
using Shops.Core.Modules;

namespace Shops.Core.Services
{
    public interface IItemService
    {
        Task<IEnumerable<Item>> GetAllItems();
    }
}