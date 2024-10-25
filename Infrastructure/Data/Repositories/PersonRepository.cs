using Domain.Entities;
using Infrastructure.Bases.Data;
using Infrastructure.Bases.Data.Repositories;
using Infrastructure.Interfaces.Repositories;

namespace Infrastructure.Data.Repositories;

public class PersonRepository : Repository<Person>, IPersonRepository
{
    public PersonRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}
