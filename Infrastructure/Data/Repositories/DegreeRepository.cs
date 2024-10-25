using Domain.Entities;
using Infrastructure.Bases.Data;
using Infrastructure.Bases.Data.Repositories;
using Infrastructure.Interfaces.Repositories;

namespace Infrastructure.Data.Repositories;

public class DegreeRepository : Repository<Degree>, IDegreeRepository
{
    public DegreeRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}
