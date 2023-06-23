using Andreitoledo.UoW.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

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
