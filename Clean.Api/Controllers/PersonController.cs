using Application.Dtos.Persons;
using Application.IServices;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Api.Server.Bases.Controllers;
using Infrastructure.Interfaces.Repositories;

namespace Api.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : BaseController<PersonDto, PersonDtoSelect, Person>
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
