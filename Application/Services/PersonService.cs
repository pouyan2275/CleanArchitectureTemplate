using Application.Bases.Implements.Services;
using Application.Dtos.Persons;
using Application.IServices;
using Domain.Entities;
using Infrastructure.Interfaces.Repositories;
namespace Application.Services;

public class PersonService : BaseService<PersonDto, PersonDtoSelect, Person>, IPersonService
{
    private readonly IPersonRepository _repository;

    public PersonService(IPersonRepository repository) : base(repository)
    {
        _repository = repository;
    }


}
