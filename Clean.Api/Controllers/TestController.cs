using Application.IServices;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Api.Server.Bases.Controllers;

namespace Api.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : BaseController<Test>
    {
        public TestController(ITestService baseService) : base(baseService)
        {
        }
    }
}
