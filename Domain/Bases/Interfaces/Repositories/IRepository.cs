using Domain.Bases.Interfaces.Entities;

namespace Domain.Bases.Interfaces.Repositories
{
    public interface IRepository<TEntity>
        where TEntity : IBaseEntity
    {
        public IQueryable<TEntity> Table { get; }
        public IQueryable<TEntity> TableNoTracking { get; }
        public Task<TEntity?> GetByIdAsync(Guid id, CancellationToken ct = default);
        public Task<TDestination?> GetByIdAsync<TDestination>(Guid id, CancellationToken ct = default);
        public Task<TEntity?> GetByIdEagleLoadingAsync(Guid id, CancellationToken ct = default);
        public Task<TDestination?> GetByIdEagleLoadingAsync<TDestination>(Guid id, CancellationToken ct = default);
        public Task<List<TEntity>> GetAllAsync(CancellationToken ct = default);
        public Task<List<TDestination>> GetAllAsync<TDestination>(CancellationToken ct = default);
        public Task<List<TEntity>> GetAllEagleLoadingAsync(CancellationToken ct = default);
        public Task<List<TDestination>> GetAllEagleLoadingAsync<TDestination>(CancellationToken ct = default);
        public Task AddAsync(TEntity Tentity, bool save = true, CancellationToken ct = default);
        public Task UpdateAsync(TEntity Tentity, bool save = true, CancellationToken ct = default);
        public Task DeleteAsync(TEntity entity, bool save = true, CancellationToken ct = default);
        public Task SaveChangesAsync(CancellationToken ct = default);
    }
}
