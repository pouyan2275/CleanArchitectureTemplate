using Application.Bases.Dtos.Paginations;
using Application.Bases.Exceptions;
using Application.Bases.Interfaces.IServices;
using Domain.Bases.Entities;
using Domain.Bases.Interfaces.Repositories;
using Mapster;

namespace Application.Bases.Implements.Services;

public class CrudService<TEntity>(IRepository<TEntity> repository) : CrudService<TEntity, TEntity, TEntity>(repository)
    where TEntity : BaseEntity{}
public class CrudService<TDto, TEntity>(IRepository<TEntity> repository) : CrudService<TDto, TDto, TEntity>(repository)
    where TEntity : BaseEntity{}

public class CrudService<TDto, TDtoSelect, TEntity> : ICrudService<TDto, TDtoSelect, TEntity>
    where TEntity : BaseEntity
{
    private readonly IRepository<TEntity> _repository;
    public CrudService(IRepository<TEntity> repository)
    {
        _repository = repository;
    }
    public virtual async Task AddAsync(TDto Tentity, CancellationToken ct = default)
    {
        Guid id;
        bool guidUsed;

        do
        {
            id = Guid.NewGuid();
            guidUsed = await _repository.GetByIdAsync(id, ct) != null;
        } while (guidUsed);

        var entity = Tentity.Adapt<TEntity>();

        entity.CreatedOn = DateTime.UtcNow;
        entity.CreatedBy = default(Guid);
        entity.Id = id;

        await _repository.AddAsync(entity, ct: ct);
    }

    public virtual async Task DeleteAsync(Guid id, CancellationToken ct = default)
    {
        await _repository.DeleteAsync(id, ct: ct);
    }

    public virtual async Task<List<TDtoSelect>> GetAllAsync(CancellationToken ct = default)
    {
        var result = await _repository.GetAllAsync<TDtoSelect>(ct);
        return result;
    }

    public virtual async Task<List<TDtoSelect>> GetAllEagleLoadingAsync(CancellationToken ct = default)
    {
        var result = await _repository.GetAllEagleLoadingAsync<TDtoSelect>(ct);
        return result;
    }

    public virtual async Task<TDtoSelect?> GetByIdAsync(Guid id, CancellationToken ct = default)
    {
        var result = await _repository.GetByIdAsync<TDtoSelect>(id, ct);
        return result;
    }

    public virtual async Task<TDtoSelect?> GetByIdEagleLoadingAsync(Guid id, CancellationToken ct = default)
    {
        var result = await _repository.GetByIdEagleLoadingAsync<TDtoSelect>(id, ct);
        return result;
    }

    public virtual async Task UpdateAsync(Guid id, TDto Tentity, CancellationToken ct = default)
    {
        TEntity entity = await _repository.GetByIdAsync(id, ct) ?? throw new NotFoundException("id",id.ToString());

        entity = Tentity.Adapt(entity);

        entity!.ModifiedOn = DateTime.UtcNow;
        entity!.ModifiedBy = default(Guid);
        entity!.Id = id;

        await _repository.UpdateAsync(entity!, ct: ct);
    }

    public async Task<PaginationDtoSelect<TDtoSelect>> PaginationAsync(PaginationDto dto,CancellationToken ct = default)
    {

        var result = await _repository.PaginationAsync<TDtoSelect>(dto.Filter, dto.Sort, dto.PageNumber, dto.PageSize, ct);

        var paginationDtoSelect = new PaginationDtoSelect<TDtoSelect>()
        {
            Count = result.Count,
            Data = result
        };
        return paginationDtoSelect;
    }
    public async Task<PaginationDtoSelect<TDtoSelect>> PaginationEagleLoadingAsync(PaginationDto dto, CancellationToken ct = default)
    {

        var result = await _repository.PaginationEagleLoadingAsync<TDtoSelect>(dto.Filter, dto.Sort, dto.PageNumber, dto.PageSize, ct);

        var paginationDtoSelect = new PaginationDtoSelect<TDtoSelect>()
        {
            Count = result.Count,
            Data = result
        };
        return paginationDtoSelect;
    }

}