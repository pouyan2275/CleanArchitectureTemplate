using Application.Bases.Dtos.Paginations;

namespace Application.Bases.Interfaces.IServices
{
    public interface IBaseService<TDto,TDtoSelect,TEntity>
    {
        public Task<TDtoSelect?> GetByIdAsync(object id, CancellationToken ct = default);
        public Task<List<TDtoSelect>> GetAllAsync(bool lazyLoading = true, CancellationToken ct = default);
        public Task AddAsync(TDto Tentity, CancellationToken ct = default);
        public Task UpdateAsync(object id, TDto Tentity, CancellationToken ct = default);
        public Task DeleteAsync(object id, CancellationToken ct = default);
        public Task<PaginationDtoSelect<TDtoSelect>> PaginationAsync(PaginationDto paginationDto, bool lazyLoading = true, CancellationToken ct = default);
    }

    public interface IBaseService<TDto, TEntity> : IBaseService<TDto,TDto,TEntity>
    {
    }
    public interface IBaseService<TEntity> : IBaseService<TEntity, TEntity, TEntity>
    {
    }
}
