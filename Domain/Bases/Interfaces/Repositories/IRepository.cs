using Domain.Bases.Interfaces.Entities;
using System.Collections.Generic;

namespace Domain.Bases.Interfaces.Repositories
{
    public interface IRepository<TEntity>
        where TEntity : IBaseEntity
    {
        public IQueryable<TEntity> Table { get; }
        public IQueryable<TEntity> TableNoTracking { get; }
        public Task<TEntity?> GetByIdAsync(Guid id, CancellationToken ct = default);
        public Task<List<TEntity>> GetAllAsync(CancellationToken ct = default);
        public Task AddAsync(TEntity Tentity, bool save = true, CancellationToken ct = default);
        public Task UpdateAsync(TEntity Tentity, bool save = true, CancellationToken ct = default);
        public Task DeleteAsync(Guid id, bool save = true, CancellationToken ct = default);
        public Task SaveChangesAsync(CancellationToken ct = default);
    }
}
