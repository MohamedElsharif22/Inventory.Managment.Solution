using Inventory.Managment.Application._Data;
using Inventory.Managment.Application.Specification;
using Inventory.Managment.Core.Entities;
using Inventory.Managment.Core.Repositories.Contracts;
using Inventory.Managment.Core.Specificarion;
using Microsoft.EntityFrameworkCore;

namespace Inventory.Managment.Application.generic_repository
{
    public class GenericRepository<TEntity>(InventoryDbContext context) : IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly InventoryDbContext _context = context;

        public async Task<TEntity?> Get(int id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }

        public async Task<IReadOnlyList<TEntity>> GetAll()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }

        public async Task<IReadOnlyList<TEntity>> GetAllWithSpecs(ISpecification<TEntity> specification)
        {
            return await ApplySpecification(specification).ToListAsync();
        }

        public async Task<TEntity?> GetWithSpecsAsync(ISpecification<TEntity> specification)
        {
            return await ApplySpecification(specification).FirstOrDefaultAsync();
        }


        protected IQueryable<TEntity> ApplySpecification(ISpecification<TEntity> specification)
        {
            return SpecificationEvaluator<TEntity>.BuildQuary(_context.Set<TEntity>(), specification);
        }
    }
}
