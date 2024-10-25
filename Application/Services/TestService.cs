using Application.Bases.Implements.Services;
using Application.IServices;
using Domain.Bases.Interfaces.Repositories;
using Domain.Entities;

namespace Application.Services;

public class TestService : BaseService<Test>, ITestService
{
    public TestService(IRepository<Test> repository) : base(repository)
    {
    }
}
