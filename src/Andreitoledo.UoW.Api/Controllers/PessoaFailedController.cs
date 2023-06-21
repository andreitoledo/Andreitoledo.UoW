using Andreitoledo.UoW.Data.FailedRepository;
using Microsoft.AspNetCore.Mvc;

namespace Andreitoledo.UoW.Api.Controllers
{
    [ApiController]
    [Route("api/Controller")]
    public class PessoaFailedController : Controller
    {
        private readonly IPessoaFailedRepository _repo;

        public PessoaFailedController(IPessoaFailedRepository repo)
        {
            _repo = repo;
        }

        [HttpGet("pagina-inicial")]
        public IActionResult Index()
        {
            return Ok();
        }
    }
}
