using Application.Bases.Dtos.Paginations;

namespace Application.Bases.Interfaces.IServices
{
    public interface ICrudService<TDto,TDtoSelect,TEntity>
    {
        public Task<TDtoSelect?> GetByIdAsync(Guid id, CancellationToken ct = default);
        public Task<List<TDtoSelect>> GetAllAsync(CancellationToken ct = default);
        public Task<TDtoSelect> AddAsync(TDto Tentity, CancellationToken ct = default);
        public Task<TDtoSelect> UpdateAsync(Guid id, TDto Tentity, CancellationToken ct = default);
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
