using Application.Bases.Dtos.Paginations;

namespace Application.Bases.Interfaces.IServices
{
    public interface ICrudService<TDto,TDtoSelect,TEntity>
    {
        public Task<TDtoSelect?> GetByIdAsync(Guid id, CancellationToken ct = default);
        public Task<List<TDtoSelect>> GetAllAsync(CancellationToken ct = default);
        public Task<TDtoSelect?> GetByIdEagleLoadingAsync(Guid id, CancellationToken ct = default);
        public Task<List<TDtoSelect>> GetAllEagleLoadingAsync(CancellationToken ct = default);
        public Task AddAsync(TDto Tentity, CancellationToken ct = default);
        public Task UpdateAsync(Guid id, TDto Tentity, CancellationToken ct = default);
        public Task DeleteAsync(Guid id, CancellationToken ct = default);
        public Task<PaginationDtoSelect<TDtoSelect>> PaginationAsync(PaginationDto paginationDto, CancellationToken ct = default);
    }

    public interface ICrudService<TDto, TEntity> : ICrudService<TDto,TDto,TEntity>
    {
    }
    public interface ICrudService<TEntity> : ICrudService<TEntity, TEntity, TEntity>
    {
    }
}
