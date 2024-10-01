using Api.Bases.Controllers;
using Application.Dtos.Persons;
using Application.IServices;
using Domain.Entities;
using Domain.Interfaces.Repositories;
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
        [HttpGet("[action]")]
        public async Task test()
        {
            await _repository.GetByIdAsync(Guid.Parse("E1870BE3-7409-46EF-8AC0-0ADEEC59E2CF"));
            await _repository.GetByIdEagleLoadingAsync(Guid.Parse("E1870BE3-7409-46EF-8AC0-0ADEEC59E2CF"));
            
        }
    }
}
