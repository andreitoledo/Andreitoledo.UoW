using Andreitoledo.UoW.Api.Models;
using Andreitoledo.UoW.Data.FailedRepository;
using Andreitoledo.UoW.Data.repositories.Abstraction;
using Andreitoledo.UoW.Domain;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Andreitoledo.UoW.Api.Controllers
{
    [ApiController]
    [Route("api/pessoa")]
    public class PessoaController : Controller
    {
        private readonly IPessoaRepository _repoPessoa;
        private readonly IVooRepository _repoVoo;
        private readonly IMapper _mapper;

        public PessoaController(IPessoaRepository repoPessoa,
                                      IVooRepository repoVoo,
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
            if (!ModelState.IsValid) return BadRequest("O modelo está inválido");

            var pessoaModel = new Pessoa
            {
                VooId = pessoa.VooId,
                Nome = pessoa.Nome                
            };

            try
            {
                await _repoPessoa.AdicionarSeAoVoo(pessoaModel);
                await _repoVoo.DecrementarVaga(pessoa.VooId);

                var transacao = await _repoPessoa.Commit();

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
