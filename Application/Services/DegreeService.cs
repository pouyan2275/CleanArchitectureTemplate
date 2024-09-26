using Application.Bases.Implements.Services;
using Application.Dtos.Degrees;
using Application.IServices;
using Domain.Entities;
using Domain.Interfaces.Repositories;
namespace Application.Services;

public class DegreeService : CrudService<DegreeDto, DegreeDtoSelect, Degree>, IDegreeService
{
    private readonly IDegreeRepository _repository;

    public DegreeService(IDegreeRepository repository) : base(repository)
    {
        _repository = repository;
    }
}
