using Application.Bases;
using Application.Bases.Dtos.Paginations;
using Application.Bases.Implements.Services;
using Application.Dtos.Categories;
using Application.IServices;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Plainquire.Page;
using System.ComponentModel;
using System.Linq.Dynamic.Core;
using System.Reflection;
using System.Text.Json;
namespace Application.Services;

public class PersonService : CrudService<PersonDto, PersonDtoSelect, Person>, IPersonService
{
    private readonly IPersonRepository _repository;

    public PersonService(IPersonRepository repository) : base(repository)
    {
        _repository = repository;
    }
}
