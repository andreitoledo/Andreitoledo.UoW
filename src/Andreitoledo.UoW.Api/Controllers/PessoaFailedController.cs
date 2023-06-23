using Andreitoledo.UoW.Api.Models;
using Andreitoledo.UoW.Data.FailedRepository;
using Andreitoledo.UoW.Domain;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Andreitoledo.UoW.Api.Controllers
{
    [ApiController]
    [Route("api/Pessoafailed")]
    public class PessoaFailedController : Controller
    {
        private readonly IPessoaFailedRepository _repoPessoa;
        private readonly IVooFailedRepository _repoVoo;
        private readonly IMapper _mapper;

        public PessoaFailedController(IPessoaFailedRepository repoPessoa,
                                      IVooFailedRepository repoVoo,
                                      IMapper mapper)
        {
            _repoPessoa = repoPessoa;
            _repoVoo = repoVoo;
            _mapper = mapper;
        }

        [HttpPost("adicionar-passageiro")]
        [ProducesResponseType(typeof(PessoaDTO), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AdicionarPassageiro(PessoaRequest pessoa)
        {
            if(!ModelState.IsValid) return BadRequest("O modelo está inválido");

            var pessoaModel = new Pessoa
            {
                Nome = pessoa.Nome,
                VooId = pessoa.VooId
            };

            try
            {
                await _repoPessoa.AdicionarSeAoVoo(pessoaModel);
                await _repoVoo.DecrementarVaga(pessoa.VooId);
                                
                return CreatedAtAction(nameof(AdicionarPassageiro), 
                    _mapper.Map<PessoaDTO>(pessoaModel));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);                
            }
            
        }
    }
}
