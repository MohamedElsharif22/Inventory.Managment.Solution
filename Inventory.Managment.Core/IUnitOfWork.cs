using Inventory.Managment.Core.Entities;
using Inventory.Managment.Core.Repositories.Contracts;

namespace Inventory.Managment.Core
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        IGenericRepository<T>? Repository<T>() where T : BaseEntity;

        Task<int> CompleteAsync();
    }
}
