using Andreitoledo.UoW.Data.Orm;
using Andreitoledo.UoW.Data.repositories.Abstraction;
using Andreitoledo.UoW.Domain;
using Microsoft.EntityFrameworkCore;

namespace Andreitoledo.UoW.Data.repositories.Implementations
{
    public class PessoaRepository : IPessoaRepository
    {
        private readonly UoWDbContext _context;

        // exemplo utilizado quando só quer executar uma linha, que não seja um return ou atribuir alguma coisa
        public PessoaRepository(UoWDbContext context) => _context = context;

        public async Task AdicionarSeAoVoo(Pessoa pessoa) => await _context.Set<Pessoa>().AddAsync(pessoa);
        
        public async Task ExcluirPessoasDoVoo(Guid vooId)
        {
            var pessoas = await _context.Set<Pessoa>().AsNoTracking().Where(p=>p.VooId == vooId).ToListAsync();
            _context.Set<Pessoa>().RemoveRange(pessoas);
        }

        public async Task<bool> Commit()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public Task Rollback()
        {
            return Task.CompletedTask;
        }
    }
}
