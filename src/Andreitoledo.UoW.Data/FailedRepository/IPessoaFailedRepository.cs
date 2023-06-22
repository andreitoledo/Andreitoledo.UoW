using Andreitoledo.UoW.Domain;

namespace Andreitoledo.UoW.Data.FailedRepository
{
    public interface IPessoaFailedRepository
    {
        Task AdicionarSeAoVoo(Pessoa pessoa);
    }
}
