using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Shops.Core.Modules;
using Shops.Core.Repositories;

namespace Shops.DataAccess.Repositories
{
    public class ItemRepository : Repository<Item>, IItemRepository
    {
        public ItemRepository(ShopsDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Item>> GetAllItems()
        {
            return await IndianShopsDbContext.Items.ToListAsync();
        }

        private ShopsDbContext IndianShopsDbContext => Context as ShopsDbContext;
    }
}