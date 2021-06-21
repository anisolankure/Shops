using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Shops.Core.Modules;

namespace Shops.Core.Services
{
    public interface IShopService
    {
        Task<IEnumerable<Shop>> GetAllShopsAsync();
        Task<Shop> GetShopByIdAsync(int id);
        IEnumerable<Shop> Find(Expression<Func<Shop, bool>> predicate);
        Task<Shop> SingleOrDefaultAsync(Expression<Func<Shop, bool>> predicate);
        Task AddShopAsync(Shop shop);
        Task AddShopsAsync(IEnumerable<Shop> shops);
        void RemoveShop(Shop shop);
        void RemoveShops(IEnumerable<Shop> shops);
    }
}