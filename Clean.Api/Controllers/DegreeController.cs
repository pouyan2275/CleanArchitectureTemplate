using Api.Bases.Controllers;
using Application.Dtos.Degrees;
using Domain.Entities;
using Application.IServices;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DegreeController : CrudController<DegreeDto, DegreeDtoSelect, Degree>
    {
        private readonly IDegreeService _crudService;

        public DegreeController(IDegreeService crudService) : base(crudService)
        {
            _crudService = crudService;
        }
    }
}
