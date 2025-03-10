using Inventory.Managment.Core.Entities;
using Inventory.Managment.Core.Repositories.Contracts;
using System.Collections;

namespace Inventory.Managment.Core
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        Hashtable _repositories { get; set; }
        IGenericRepository<T> Repository<T>() where T : BaseEntity;

        Task<int> CompleteAsync();
    }
}
