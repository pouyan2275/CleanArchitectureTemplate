using Application.Bases.Dtos.Paginations;
using Application.Bases.Interfaces.IServices;
using Domain.Bases.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Api.Bases.Controllers;
/// <summary>
/// Restfull api
/// </summary>
/// <typeparam name="TEntity"></typeparam>
/// <param name="repository"></param>
[Route("api/[controller]")]
[ApiController]
public class CrudController<TEntity>(ICrudService<TEntity> crudService) : CrudController<TEntity, TEntity, TEntity>(crudService) where TEntity : BaseEntity { }
public class CrudController<TDto, TEntity>(ICrudService<TDto, TEntity> crudService) : CrudController<TDto, TDto, TEntity>(crudService) where TEntity : BaseEntity { }

public class CrudController<TDto, TDtoSelect, TEntity> : ControllerBase
    where TEntity : BaseEntity
{
    private readonly ICrudService<TDto,TDtoSelect,TEntity> _crudService;

    public CrudController(ICrudService<TDto, TDtoSelect, TEntity> crudService)
    {
        _crudService = crudService;
    }
    /// <summary>
    /// Get By Id
    /// </summary>
    /// <param name="id"></param>
    /// <param name="ct"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public virtual async Task<ActionResult<TDtoSelect?>> GetById(Guid id, CancellationToken ct = default)
    {
        var result = await _crudService.GetByIdAsync(id, ct);
        return Ok(result);
    }

    /// <summary>
    /// Get by id with relations
    /// </summary>
    /// <param name="id"></param>
    /// <param name="ct"></param>
    /// <returns></returns>
    [HttpGet("[action]/{id}")]
    public virtual async Task<ActionResult<TDtoSelect?>> GetByIdWithRelations(Guid id, CancellationToken ct = default)
    {
        var result = await _crudService.GetByIdEagleLoadingAsync(id, ct);
        return Ok(result);
    }

    /// <summary>
    /// Get All
    /// </summary>
    /// <param name="ct"></param>
    /// <returns></returns>
    [HttpGet]
    public virtual async Task<ActionResult<List<TDtoSelect>>> GetAll(CancellationToken ct = default)
    {
       
        var result = await _crudService.GetAllAsync(ct);
        return Ok(result);
    }

    /// <summary>
    /// Get all with relations
    /// </summary>
    /// <param name="ct"></param>
    /// <returns></returns>
    [HttpGet("[action]")]
    public virtual async Task<ActionResult<List<TDtoSelect>>> GetAllWithRelations(CancellationToken ct = default)
    {

        var result = await _crudService.GetAllEagleLoadingAsync(ct);
        return Ok(result);
    }

    /// <summary>
    /// Create New
    /// </summary>
    /// <param name="Tentity"></param>
    /// <param name="ct"></param>
    /// <returns></returns>
    [HttpPost]
    public virtual async Task Add(TDto Tentity, CancellationToken ct = default)
    {
        await _crudService.AddAsync(Tentity, ct);
    }

    /// <summary>
    /// Edit a Entity
    /// </summary>
    /// <param name="id"></param>
    /// <param name="Tentity"></param>
    /// <param name="ct"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public virtual async Task Update(Guid id, TDto Tentity, CancellationToken ct = default)
    {
        await _crudService.UpdateAsync(id, Tentity, ct);
    }

    /// <summary>
    /// Delete a Entity
    /// </summary>
    /// <param name="id"></param>
    /// <param name="ct"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public virtual async Task<ActionResult> Delete(Guid id, CancellationToken ct = default)
    {
        await _crudService.DeleteAsync(id, ct: ct);
        return Ok();
    }
    /// <summary>
    /// pagination
    /// </summary>
    /// <param name="pagination"></param>
    /// <returns></returns>
    [HttpPost("[action]")]
    public async Task<ActionResult<PaginationDtoSelect<TDtoSelect>>> Pagination(PaginationDto pagination,CancellationToken ct = default)
    {
        var result = await _crudService.PaginationAsync(pagination,ct: ct);
        return Ok(result);
    }

    /// <summary>
    /// PaginationEagleLoadingAsync
    /// </summary>
    /// <param name="pagination"></param>
    /// <returns></returns>
    [HttpPost("[action]")]
    public async Task<ActionResult<PaginationDtoSelect<TDtoSelect>>> PaginationEagleLoading(PaginationDto pagination, CancellationToken ct = default)
    {
        var result = await _crudService.PaginationEagleLoadingAsync(pagination, ct: ct);
        return Ok(result);
    }
}
