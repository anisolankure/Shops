using System;
using System.Threading.Tasks;
using Shops.Core.Repositories;

namespace Shops.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IShopRepository Shops { get; }
        IItemRepository Items { get; }
        Task<int> CommitAsync();
    }
}