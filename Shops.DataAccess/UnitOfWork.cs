using System.Threading.Tasks;
using Shops.Core;
using Shops.Core.Repositories;
using Shops.DataAccess.Repositories;

namespace Shops.DataAccess
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ShopsDbContext _context;
        private ShopRepository _shopRepository;
        private ItemRepository _itemRepository;

        public UnitOfWork(ShopsDbContext context)
        {
            _context = context;
        }

        public void Dispose()
        {
           _context.Dispose();
        }

        public IShopRepository Shops => _shopRepository ??= new ShopRepository(_context);
        public IItemRepository Items => _itemRepository ??= new ItemRepository(_context);
        public Task<int> CommitAsync()
        {
            return _context.SaveChangesAsync();
        }
    }
}