using Andreitoledo.UoW.Data.FailedRepository;
using Andreitoledo.UoW.Data.Orm;
using Andreitoledo.UoW.Domain;

namespace Andreitoledo.UoW.Data.FailedRepository

{
    public interface IVooFailedRepository
    {
        Task AdicionarPassageiro(Guid? vooId);            
    }    
}

public class VooFailedRepository : IVooFailedRepository
{
    private readonly UoWDbContext _context;

    public VooFailedRepository(UoWDbContext context)
    {
        _context = context;
    }

    public async Task AdicionarPassageiro(Guid? vooId)
    {
        if (vooId == null)
            throw new Exception("Id do Voo não pode ser nulo.");

        var voo = await _context.Voo.FindAsync(vooId);

        if (voo == null)
            throw new Exception("Voo não encontrado.");

        if (!voo.TemDisponibilidade())
            throw new Exception("Não há mais vagas disponível para este voo!");

        voo.DecrementaDisponibilidade();

        _context.Set<Voo>().Update(voo);
        await _context.SaveChangesAsync();
    }
}







