using Api.Bases.Controllers;
using Application.Bases.Dtos.Paginations;
using Application.Dtos.Categories;
using Application.IServices;
using Application.Services;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : CrudController<PersonDto, PersonDtoSelect, Person>
    {
        private readonly IPersonService _personService;
        private readonly IPersonRepository _repository;

        public PersonController(IPersonService personService, IPersonRepository repository) : base(personService)
        {
            _personService = personService;
            _repository = repository;
        }
    }
}
