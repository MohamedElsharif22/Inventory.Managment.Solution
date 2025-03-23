using Inventory.Managment.Application._Data;
using Inventory.Managment.Application.generic_repository;
using Inventory.Managment.Core;
using Inventory.Managment.Core.Entities;
using Inventory.Managment.Core.Repositories.Contracts;
using System.Collections;

namespace Inventory.Managment.Application
{
    public sealed class UnitOfWork(InventoryDbContext context) : IUnitOfWork
    {
        private readonly InventoryDbContext _context = context;

        private Hashtable _repositories { get; set; } = [];

        public async Task<int> CompleteAsync()
        {
            return await CompleteAsync();
        }

        public async ValueTask DisposeAsync()
        {
            await _context.DisposeAsync();
        }

        public IGenericRepository<TEntity>? Repository<TEntity>() where TEntity : BaseEntity
        {
            string key = typeof(TEntity).Name;
            if (!_repositories.ContainsKey(key))
            {
                var repo = new GenericRepository<TEntity>(_context);
                _repositories.Add(key, repo);
            }
            return _repositories[key] as IGenericRepository<TEntity>;
        }
    }
}
