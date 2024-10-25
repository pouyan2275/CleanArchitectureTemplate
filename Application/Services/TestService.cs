using Application.Bases.Implements.Services;
using Application.IServices;
using Domain.Entities;
using Infrastructure.Bases.Data;
using Infrastructure.Bases.Interfaces.Repositories;

namespace Application.Services;

public class TestService : BaseService<Test>, ITestService
{
    public TestService(IRepository<Test> repository,DbContextFactory db) : base(repository)
    {
    }
}
