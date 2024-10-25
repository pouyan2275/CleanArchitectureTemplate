using Domain.Bases.Interfaces.Repositories;
using Domain.Bases.Models.FilterParams;
using Domain.Bases.Models.SortParams;
using Mapster;
using Microsoft.EntityFrameworkCore;


namespace Infrastructure.Bases.Data.Repositories;

public class Repository<TEntity> : IRepository<TEntity>
    where TEntity : class
{
    private readonly ApplicationDbContext _dbContext;
    public readonly DbSet<TEntity> Entity;
    public IQueryable<TEntity> Table { get { return _dbContext.Set<TEntity>().AsTracking().AsQueryable(); } }
    public IQueryable<TEntity> TableNoTracking { get { return _dbContext.Set<TEntity>().AsNoTracking().AsQueryable(); } }

    public Repository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
        Entity = _dbContext.Set<TEntity>();
    }

    public virtual async Task AddAsync(TEntity Tentity, bool save = true, CancellationToken ct = default)
    {
        await Entity.AddAsync(Tentity, ct);
        if (save)
            await SaveChangesAsync(ct);
    }

    public virtual async Task SaveChangesAsync(CancellationToken ct = default)
    {
        await _dbContext.SaveChangesAsync(ct);
    }

    public virtual async Task<List<TEntity>> GetAllAsync(CancellationToken ct = default)
    {
        var result = await Entity.ToListAsync(cancellationToken: ct);
        return result;
    }

    public virtual async Task<List<TDestination>> GetAllAsync<TDestination>(CancellationToken ct = default)
    {
        var result = (await Entity.ToListAsync(cancellationToken: ct)).Adapt<List<TDestination>>();
        return result;
    }

    public virtual async Task<List<TDestination>> GetAllEagleLoadingAsync<TDestination>(CancellationToken ct = default)
    {
        var result = await Entity.ProjectToType<TDestination>().ToListAsync(cancellationToken: ct);
        return result;
    }
    public virtual async Task<List<TEntity>> GetAllEagleLoadingAsync(CancellationToken ct = default)
    {
        var result = await Entity.ProjectToType<TEntity>().ToListAsync(cancellationToken: ct);
        return result;
    }

    public virtual async Task<TEntity?> GetByIdAsync(object id, CancellationToken ct = default)
    {
        var record = await Entity.FindAsync(id);
        await SaveChangesAsync(ct);
        return record;
    }

    public virtual async Task<TDestination?> GetByIdAsync<TDestination>(object id, CancellationToken ct = default)
    {
        var record = (await Entity.FindAsync(id)).Adapt<TDestination>();
        await SaveChangesAsync(ct);
        return record;
    }

    public virtual async Task UpdateAsync(TEntity Tentity, bool save = true, CancellationToken ct = default)
    {
        Entity.Update(Tentity);
        if (save)
            await SaveChangesAsync(ct);
    }

    public virtual async Task DeleteAsync(object id, bool save = true, CancellationToken ct = default)
    {
        var result = await Entity.FindAsync(id);
        Entity.Remove(result!);
    }

    public virtual async Task DeleteRecordAsync(object id, bool save = true, CancellationToken ct = default)
    {
        var result = await Entity.FindAsync(id);
        Entity.Remove(result!);
    }

    public virtual async Task<List<TDestination>> PaginationEagleLoadingAsync<TDestination>(List<FilterParam>? filterParams,
        List<SortParam>? sortParams,
        int pageNumber = 1,
        int pageSize = int.MaxValue,
        CancellationToken ct = default)
    {
        var query = TableNoTracking.Filter(filterParams).Sort(sortParams).Page(pageNumber, pageSize);

        var result = await query.ProjectToType<TDestination>().ToListAsync(ct);

        return result;
    }
    public virtual async Task<List<TEntity>> PaginationEagleLoadingAsync(List<FilterParam>? filterParams,
    List<SortParam>? sortParams,
    int pageNumber = 1,
    int pageSize = int.MaxValue,
    CancellationToken ct = default)
    {
        var query = TableNoTracking.Filter(filterParams).Sort(sortParams).Page(pageNumber, pageSize);

        var result = await query.ProjectToType<TEntity>().ToListAsync(ct);

        return result;
    }
    public virtual async Task<List<TEntity>> PaginationAsync(List<FilterParam>? filterParams,
        List<SortParam>? sortParams,
        int pageNumber = 1,
        int pageSize = int.MaxValue,
        CancellationToken ct = default)
    {
        var query = TableNoTracking.Filter(filterParams).Sort(sortParams).Page(pageNumber, pageSize);

        var result = await query.ToListAsync(ct);

        return result;
    }
    public virtual async Task<List<TDestination>> PaginationAsync<TDestination>(List<FilterParam>? filterParams,
        List<SortParam>? sortParams,
        int pageNumber = 1,
        int pageSize = int.MaxValue,
        CancellationToken ct = default)
    {
        var query = TableNoTracking.Filter(filterParams).Sort(sortParams).Page(pageNumber, pageSize);

        var result = (await query.ToListAsync(ct)).Adapt<List<TDestination>>();

        return result;
    }
}
