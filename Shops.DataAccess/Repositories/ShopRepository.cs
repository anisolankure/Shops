using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Shops.Core.Modules;
using Shops.Core.Repositories;

namespace Shops.DataAccess.Repositories
{
    public class ShopRepository : Repository<Shop>, IShopRepository
    {
        public ShopRepository(ShopsDbContext context) : base(context) { }

        public async Task<IEnumerable<Shop>> GetAllShopsWithItems()
        {
            return await ShopsDbContext.Shops.ToListAsync();
        }

        private ShopsDbContext ShopsDbContext => Context as ShopsDbContext;
    }
}