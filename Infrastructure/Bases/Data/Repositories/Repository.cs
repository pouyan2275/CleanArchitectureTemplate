using Domain.Bases.Interfaces.Entities;
using Domain.Bases.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Bases.Data.Repositories;

public class Repository<TEntity> : IRepository<TEntity>
    where TEntity : class, IBaseEntity
{
    private readonly ApplicationDbContext _dbContext;
    private readonly DbSet<TEntity> Entity;
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

    public virtual async Task<TEntity?> GetByIdAsync(Guid id, CancellationToken ct = default)
    {
        var record = await TableNoTracking.FirstOrDefaultAsync(x => x.Id == id, cancellationToken: ct);
        return record;
    }

    public virtual async Task UpdateAsync(TEntity Tentity, bool save = true, CancellationToken ct = default)
    {
        Entity.Update(Tentity);
        if (save)
            await SaveChangesAsync(ct);
    }

    public virtual async Task DeleteAsync(Guid id, bool save = true, CancellationToken ct = default)
    {
        var record = await GetByIdAsync(id, ct);
        Entity.Remove(record!);
        await SaveChangesAsync(ct);
    }
}
