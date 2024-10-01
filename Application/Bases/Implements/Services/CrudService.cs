using Application.Bases.Dtos.Paginations;
using Application.Bases.Exceptions;
using Application.Bases.Interfaces.IServices;
using Domain.Bases.Interfaces.Entities;
using Domain.Bases.Interfaces.Repositories;
using Mapster;
using Microsoft.EntityFrameworkCore;
using Plainquire.Page;
using System.Linq.Dynamic.Core;

namespace Application.Bases.Implements.Services;

public class CrudService<TEntity>(IRepository<TEntity> repository) : CrudService<TEntity, TEntity, TEntity>(repository)
    where TEntity : IBaseEntity{}
public class CrudService<TDto, TEntity>(IRepository<TEntity> repository) : CrudService<TDto, TDto, TEntity>(repository)
    where TEntity : IBaseEntity{}

public class CrudService<TDto, TDtoSelect, TEntity> : ICrudService<TDto, TDtoSelect, TEntity>
    where TEntity : IBaseEntity
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
        var record = await _repository.GetByIdAsync(id, ct);
        record = record ?? throw new NotFoundException("id", id.ToString());
        await _repository.DeleteAsync(record, ct: ct);
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

    public async Task<PaginationDtoSelect<TDtoSelect>> PaginationAsync(PaginationDto paginationDto,CancellationToken ct = default)
    {
        var table = _repository.TableNoTracking;

        paginationDto.PageNumber = paginationDto.PageNumber <= 0 ? 1 : paginationDto.PageNumber;
        paginationDto.PageSize = paginationDto.PageSize <= 0 ? int.MaxValue : paginationDto.PageSize;

        if (paginationDto?.Filter?.Count > 0)
        {
            var filterString = "x => ";

            paginationDto.Filter.ForEach(x => {
                filterString += x.Operator switch
                {
                    FilterOperator.Contains => $" x.{x.Key}.ToString().Contains(\"{x.Value}\") and",
                    FilterOperator.IsNull => $" x.{x.Key} == null and",
                    FilterOperator.NotNull => $" x.{x.Key} != null and",
                    _ => $" x.{x.Key} {x.Operator.AttributeDescription()} \"{x.Value}\" and",
                };
            });
            filterString = filterString[..(filterString.Length - 3)];
            table = table.Where(filterString);
        }

        if (paginationDto?.Sort?.Count > 0)
        {
            var sortString = "";

            paginationDto.Sort.ForEach(x => sortString += x.Key + (x.Desc ? " desc ," : " ,"));
            sortString = sortString[..(sortString.Length - 1)];
            table = table.OrderBy(sortString);
        }

        table = table.Page(paginationDto?.PageNumber, paginationDto?.PageSize);
        var result = await table.ProjectToType<TDtoSelect>().ToListAsync(ct);

        var paginationDtoSelect = new PaginationDtoSelect<TDtoSelect>()
        {
            Count = result.Count,
            Data = result
        };
        return paginationDtoSelect;
    }
}
