using Andreitoledo.UoW.Api.Controllers.Models;
using Andreitoledo.UoW.Data.FailedRepository;
using Microsoft.AspNetCore.Mvc;

namespace Andreitoledo.UoW.Api.Controllers
{
    [ApiController]
    [Route("api/Pessoafailed")]
    public class PessoaFailedController : Controller
    {
        private readonly IPessoaFailedRepository _repo;

        public PessoaFailedController(IPessoaFailedRepository repo)
        {
            _repo = repo;
        }

        [HttpPost("adicionar-passageiro")]
        public async Task<ActionResult<PessoaDTO>> AdicionarPassageiro(PessoaRequest pessoa)
        {
            return Ok();
        }
    }
}
