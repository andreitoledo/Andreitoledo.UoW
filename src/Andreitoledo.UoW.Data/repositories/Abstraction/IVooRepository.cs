using Andreitoledo.UoW.Domain;
using System.Linq.Expressions;

namespace Andreitoledo.UoW.Data.repositories.Abstraction
{
    public interface IVooRepository : IUnitOfWork
    {
        Task DecrementarVaga(Guid? vooId);
        Task UpdateVoo(Voo voo);
        Task<Voo> SelecionarPorId(Guid? id);
        Task<IEnumerable<Voo>> SelecionarTodos(Expression<Func<Voo, bool>> quando = null);
        Task Criar(Voo voo);

    }
}
