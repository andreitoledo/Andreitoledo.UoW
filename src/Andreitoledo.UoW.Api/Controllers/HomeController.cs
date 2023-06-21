using Microsoft.AspNetCore.Mvc;

namespace Andreitoledo.UoW.Api.Controllers
{
    [ApiController]
    [Route("api/Controller")]
    public class HomeController : Controller
    {
        [HttpGet("pagina-inicial")]
        public IActionResult Index()
        {
            return Ok();
        }
    }
}
