using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Shops.Core.Modules;

namespace Shops.Core.Services
{
    public interface IItemService
    {
        Task<IEnumerable<Item>> GetAllItemsAsync();
        Task<Item> GetItemByIdAsync(int id);
        IEnumerable<Item> Find(Expression<Func<Item, bool>> predicate);
        Task<Item> SingleOrDefaultAsync(Expression<Func<Item, bool>> predicate);
        Task AddItemAsync(Item item);
        Task AddItemsAsync(IEnumerable<Item> items);
        void RemoveItem(Item item);
        void RemoveItems(IEnumerable<Item> items);
    }
}