using Inventory.Managment.Core.Entities;
using Inventory.Managment.Core.Specification;

namespace Inventory.Managment.Core.Repositories.Contracts
{
    public interface IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        Task<IReadOnlyList<TEntity>> GetAllAsync();
        Task<TEntity?> GetAsync(int id);

        Task<int> GetCountAsync(ISpecification<TEntity> specification);

        Task<IReadOnlyList<TEntity>> GetAllWithSpecsAsync(ISpecification<TEntity> specification);
        Task<TEntity?> GetWithSpecsAsync(ISpecification<TEntity> specification);

    }
}
