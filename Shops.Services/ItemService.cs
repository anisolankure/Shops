using System;
using System.Collections.Generic;
using System.Linq.Expressions;
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

        public Task<IEnumerable<Item>> GetAllItemsAsync()
        {
            return _unitOfWork.Items.GetAllItemsWithShop();
        }

        public async Task<Item> GetItemByIdAsync(int id)
        {
            return await _unitOfWork.Items.GetByIdAsync(id);
        }

        public IEnumerable<Item> Find(Expression<Func<Item, bool>> predicate)
        {
            return _unitOfWork.Items.Find(predicate);
        }

        public async Task<Item> SingleOrDefaultAsync(Expression<Func<Item, bool>> predicate)
        {
            return await _unitOfWork.Items.SingleOrDefaultAsync(predicate);
        }

        public async Task AddItemAsync(Item item)
        {
            await _unitOfWork.Items.AddAsync(item);
        }

        public async Task AddItemsAsync(IEnumerable<Item> items)
        {
            await _unitOfWork.Items.AddRangeAsync(items);
        }

        public void RemoveItem(Item item)
        {
            _unitOfWork.Items.Remove(item);
        }

        public void RemoveItems(IEnumerable<Item> items)
        {
           _unitOfWork.Items.RemoveRange(items);
        }
    }
}
