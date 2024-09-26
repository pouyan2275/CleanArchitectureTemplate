using Domain.Entities;
using Domain.Interfaces.Repositories;
using Infrastructure.Bases.Data;
using Infrastructure.Bases.Data.Repositories;

namespace Infrastructure.Data.Repositories;

public class PersonRepository : Repository<Person>, IPersonRepository
{
    public PersonRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}
