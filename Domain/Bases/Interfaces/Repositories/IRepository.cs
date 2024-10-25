using Domain.Bases.Entities;
using Domain.Bases.Models.FilterParams;
using Domain.Bases.Models.SortParams;

namespace Domain.Bases.Interfaces.Repositories
{
    public interface IRepository<TEntity>
        where TEntity : class
    {
        public IQueryable<TEntity> Table { get; }
        public IQueryable<TEntity> TableNoTracking { get; }
        public Task<TEntity?> GetByIdAsync(object id, CancellationToken ct = default);
        public Task<TDestination?> GetByIdAsync<TDestination>(object id, CancellationToken ct = default);
        public Task<List<TEntity>> GetAllAsync(CancellationToken ct = default);
        public Task<List<TDestination>> GetAllAsync<TDestination>(CancellationToken ct = default);
        public Task<List<TEntity>> GetAllEagleLoadingAsync(CancellationToken ct = default);
        public Task<List<TDestination>> GetAllEagleLoadingAsync<TDestination>(CancellationToken ct = default);
        public Task AddAsync(TEntity Tentity, bool save = true, CancellationToken ct = default);
        public Task UpdateAsync(TEntity Tentity, bool save = true, CancellationToken ct = default);
        public Task DeleteAsync(object entity, bool save = true, CancellationToken ct = default);
        public Task DeleteRecordAsync(object entity, bool save = true, CancellationToken ct = default);
        public Task<List<TEntity>> PaginationAsync(List<FilterParam>? filterParams, 
            List<SortParam>? sortParams, 
            int pageNumber = 1, 
            int pageSize = int.MaxValue,
            CancellationToken ct = default);
        public Task<List<TDestination>> PaginationAsync<TDestination>(List<FilterParam>? filterParams,
            List<SortParam>? sortParams,
            int pageNumber = 1,
            int pageSize = int.MaxValue,
            CancellationToken ct = default);
        public Task<List<TEntity>> PaginationEagleLoadingAsync(List<FilterParam>? filterParams,
            List<SortParam>? sortParams,
            int pageNumber = 1,
            int pageSize = int.MaxValue,
            CancellationToken ct = default);
        public Task<List<TDestination>> PaginationEagleLoadingAsync<TDestination>(List<FilterParam>? filterParams,
            List<SortParam>? sortParams,
            int pageNumber = 1,
            int pageSize = int.MaxValue,
            CancellationToken ct = default);

        public Task SaveChangesAsync(CancellationToken ct = default);
    }
}
