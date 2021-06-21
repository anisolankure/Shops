using System;
using System.Collections.Generic;
using System.Linq.Expressions;
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

        public async Task<IEnumerable<Shop>> GetAllShopsAsync()
        {
            var result = await _unitOfWork.Shops.GetAllAsync();
            return result;
        }

        public async Task<Shop> GetShopByIdAsync(int id)
        {
            return await _unitOfWork.Shops.GetByIdAsync(id);
        }

        public IEnumerable<Shop> Find(Expression<Func<Shop, bool>> predicate)
        {
            return _unitOfWork.Shops.Find(predicate);
        }

        public async Task<Shop> SingleOrDefaultAsync(Expression<Func<Shop, bool>> predicate)
        {
            return await _unitOfWork.Shops.SingleOrDefaultAsync(predicate);
        }

        public async Task AddShopAsync(Shop shop)
        {
            await _unitOfWork.Shops.AddAsync(shop);
            await _unitOfWork.CommitAsync();
        }

        public async Task AddShopsAsync(IEnumerable<Shop> shops)
        {
            await _unitOfWork.Shops.AddRangeAsync(shops);
            await _unitOfWork.CommitAsync();
        }

        public void RemoveShop(Shop shop)
        {
            _unitOfWork.Shops.Remove(shop);
            _unitOfWork.CommitAsync();
        }

        public void RemoveShops(IEnumerable<Shop> shops)
        {
            _unitOfWork.Shops.RemoveRange(shops);
            _unitOfWork.CommitAsync();
        }
    }
}
