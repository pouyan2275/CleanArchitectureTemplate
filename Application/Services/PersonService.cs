using Application.Bases.Implements.Services;
using Application.Dtos.Persons;
using Application.IServices;
using Domain.Entities;
using Domain.Interfaces.Repositories;
namespace Application.Services;

public class PersonService : CrudService<PersonDto, PersonDtoSelect, Person>, IPersonService
{
    private readonly IPersonRepository _repository;

    public PersonService(IPersonRepository repository) : base(repository)
    {
        _repository = repository;
    }
}
