using Microsoft.AspNetCore.Mvc;

namespace Andreitoledo.UoW.Api.Controllers
{
    [ApiController]
    [Route("api/pagina-inicial")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return Ok();
        }
    }
}
