using Application.Bases.Dtos.Paginations;
using Application.Bases.Exceptions;
using Application.Bases.Interfaces.IServices;
using Domain.Bases.Entities;
using Domain.Bases.Interfaces.Repositories;
using Mapster;

namespace Application.Bases.Implements.Services;

public class BaseService<TEntity>(IRepository<TEntity> repository) : BaseService<TEntity, TEntity, TEntity>(repository)
    where TEntity : class
{ }
public class BaseService<TDto, TEntity>(IRepository<TEntity> repository) : BaseService<TDto, TDto, TEntity>(repository)
    where TEntity : class
{ }

public class BaseService<TDto, TDtoSelect, TEntity> : IBaseService<TDto, TDtoSelect, TEntity>
    where TEntity : class
{
    private readonly IRepository<TEntity> _repository;
    public BaseService(IRepository<TEntity> repository)
    {
        _repository = repository;
    }
    public virtual async Task AddAsync(TDto Tentity, CancellationToken ct = default)
    {
        //Guid id;
        //bool guidUsed;

        //do
        //{
        //    id = Guid.NewGuid();
        //    guidUsed = await _repository.GetByIdAsync(id, ct) != null;
        //} while (guidUsed);

        var entity = Tentity.Adapt<TEntity>();

        //entity.CreatedOn = DateTime.Now;
        //entity.CreatedBy = default(Guid);
        //entity.Id = id;

        await _repository.AddAsync(entity, ct: ct);
    }

    public virtual async Task DeleteAsync(object id, CancellationToken ct = default)
    {
        await _repository.DeleteAsync(id, ct: ct);
    }

    public virtual async Task<List<TDtoSelect>> GetAllAsync(bool lazyLoading = true, CancellationToken ct = default)
    {
        List<TDtoSelect> result;
        result = lazyLoading ?
            await _repository.GetAllAsync<TDtoSelect>(ct):
            await _repository.GetAllEagleLoadingAsync<TDtoSelect>(ct);
        return result;
    }

    public virtual async Task<TDtoSelect?> GetByIdAsync(object id, CancellationToken ct = default)
    {
        TDtoSelect? result;
        result = await _repository.GetByIdAsync<TDtoSelect>(id, ct);
        return result;
    }

    public virtual async Task UpdateAsync(object id, TDto Tentity, CancellationToken ct = default)
    {
        TEntity entity = await _repository.GetByIdAsync(id, ct) ?? throw new NotFoundException("id", id.ToString());

        entity = Tentity.Adapt(entity);

        //entity!.ModifiedOn = DateTime.Now;
        //entity!.ModifiedBy = default(object);
        //entity!.Id = id;

        await _repository.UpdateAsync(entity!, ct: ct);
    }

    public async Task<PaginationDtoSelect<TDtoSelect>> PaginationAsync(PaginationDto dto,bool lazyLoading = true, CancellationToken ct = default)
    {

        List<TDtoSelect> result;
        result = lazyLoading ?
            await _repository.PaginationAsync<TDtoSelect>(dto.Filter, dto.Sort, dto.PageNumber, dto.PageSize, ct):
            await _repository.PaginationEagleLoadingAsync<TDtoSelect>(dto.Filter, dto.Sort, dto.PageNumber, dto.PageSize, ct);

        var paginationDtoSelect = new PaginationDtoSelect<TDtoSelect>()
        {
            Count = result.Count,
            Data = result
        };
        return paginationDtoSelect;
    }

}