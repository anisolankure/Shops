using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Shops.Core.Modules;
using Shops.Core.Repositories;

namespace Shops.DataAccess.Repositories
{
    public class ItemRepository : Repository<Item>, IItemRepository
    {
        public ItemRepository(DbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Item>> GetAllItemsWithShop()
        {
            return await ShopsDbContext.Items.ToListAsync();
        }

        private ShopsDbContext ShopsDbContext => Context as ShopsDbContext;
    }
}