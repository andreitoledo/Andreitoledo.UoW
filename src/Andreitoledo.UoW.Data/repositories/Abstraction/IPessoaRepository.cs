using Andreitoledo.UoW.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Andreitoledo.UoW.Data.repositories.Abstraction
{
    public interface IPessoaRepository : IUnitOfWork
    {
        Task AdicionarSeAoVoo(Pessoa pessoa);
        Task ExcluirPessoaDoVoo(Guid vooId);
    }
}
