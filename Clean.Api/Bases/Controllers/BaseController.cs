using Application.Bases.Dtos.Paginations;
using Application.Bases.Interfaces.IServices;
using Domain.Bases.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Personal.Server.Bases.Controllers;
/// <summary>
/// Restfull api
/// </summary>
/// <typeparam name="TEntity"></typeparam>
/// <param name="repository"></param>
[Route("api/[controller]")]
[ApiController]
public class BaseController<TEntity>(IBaseService<TEntity> baseService) : BaseController<TEntity, TEntity, TEntity>(baseService) where TEntity : BaseEntity { }
public class BaseController<TDto, TEntity>(IBaseService<TDto, TEntity> baseService) : BaseController<TDto, TDto, TEntity>(baseService) where TEntity : BaseEntity { }

public class BaseController<TDto, TDtoSelect, TEntity> : ControllerBase
    where TEntity : BaseEntity
{
    private readonly IBaseService<TDto, TDtoSelect, TEntity> _baseService;

    public BaseController(IBaseService<TDto, TDtoSelect, TEntity> baseService)
    {
        _baseService = baseService;
    }
    /// <summary>
    /// Get By Id
    /// </summary>
    /// <param name="id"></param>
    /// <param name="ct"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public virtual async Task<ActionResult<TDtoSelect?>> GetById(Guid id,bool lazyLoading = true, CancellationToken ct = default)
    {
        var result = await _baseService.GetByIdAsync(id, lazyLoading, ct: ct);
        return Ok(result);
    }

    /// <summary>
    /// Get All
    /// </summary>
    /// <param name="ct"></param>
    /// <returns></returns>
    [HttpGet]
    public virtual async Task<ActionResult<List<TDtoSelect>>> GetAll(bool lazyLoading = true ,CancellationToken ct = default)
    {

        var result = await _baseService.GetAllAsync(lazyLoading,ct: ct);
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
        await _baseService.AddAsync(Tentity, ct);
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
        await _baseService.UpdateAsync(id, Tentity, ct);
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
        await _baseService.DeleteAsync(id, ct: ct);
        return Ok();
    }
    /// <summary>
    /// pagination
    /// </summary>
    /// <param name="pagination"></param>
    /// <returns></returns>
    [HttpPost("[action]")]
    public async Task<ActionResult<PaginationDtoSelect<TDtoSelect>>> Pagination(PaginationDto pagination,bool lazyLoading=true, CancellationToken ct = default)
    {
        var result = await _baseService.PaginationAsync(pagination,lazyLoading, ct: ct);
        return Ok(result);
    }

}
