using Inventory.Managment.Core.Entities;
using Inventory.Managment.Core.Specificarion;

namespace Inventory.Managment.Core.Repositories.Contracts
{
    public interface IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        Task<IReadOnlyList<TEntity>> GetAll();
        Task<TEntity?> Get(int id);
        Task<IReadOnlyList<TEntity>> GetAllWithSpecs(ISpecification<TEntity> specification);
        Task<TEntity?> GetWithSpecsAsync(ISpecification<TEntity> specification);

    }
}
