using Application.Dtos.Degrees;
using Domain.Entities;
using Application.IServices;
using Microsoft.AspNetCore.Mvc;
using Personal.Server.Bases.Controllers;

namespace Personal.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DegreeController : BaseController<DegreeDto, DegreeDtoSelect, Degree>
    {
        private readonly IDegreeService _baseService;

        public DegreeController(IDegreeService baseService) : base(baseService)
        {
            _baseService = baseService;
        }
    }
}
