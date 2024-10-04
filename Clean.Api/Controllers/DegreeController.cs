using Application.Dtos.Degrees;
using Domain.Entities;
using Application.IServices;
using Microsoft.AspNetCore.Mvc;
using Personal.Server.Bases.Controllers;

namespace Personal.Server.Controllers
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
