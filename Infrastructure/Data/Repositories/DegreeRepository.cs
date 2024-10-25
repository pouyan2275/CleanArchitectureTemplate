using Domain.Entities;
using Domain.Interfaces.Repositories;
using Infrastructure.Bases.Data;
using Infrastructure.Bases.Data.Repositories;

namespace Infrastructure.Data.Repositories;

public class DegreeRepository : Repository<Degree>, IDegreeRepository
{
    public DegreeRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}
