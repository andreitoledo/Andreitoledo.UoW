﻿using Andreitoledo.UoW.Data.Orm;
using Andreitoledo.UoW.Data.repositories.Abstraction;
using Andreitoledo.UoW.Domain;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Andreitoledo.UoW.Data.repositories.Implementations
{
    public class VooRepository : IVooRepository
    {

        private readonly UoWDbContext _context;

        public VooRepository(UoWDbContext context)
        {
            _context = context;
        }

        public async Task Criar(Voo voo)
        {
            var vooExistente = await _context.Set<Voo>().FindAsync(voo.Id);
            if (vooExistente == null)
                await _context.Set<Voo>().AddAsync(voo);
        }

        public async Task DecrementarVaga(Guid? vooId)
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
        }

        public async Task<Voo> SelecionarPorId(Guid? id)
        {
            return await _context.Set<Voo>().FindAsync(id);            
        }

        public async  Task<IEnumerable<Voo>> SelecionarTodos(Expression<Func<Voo, bool>> quando = null)
        {
            if (quando == null)
            {
                return await _context.Set<Voo>().Include(p => p.Pessoas).AsNoTracking().ToListAsync();
            }
            return await _context.Set<Voo>().Include(p => p.Pessoas).AsNoTracking().Where(quando).ToListAsync();
        }

        public async Task UpdateVoo(Voo voo)
        {
            _context.Set<Voo>().Update(voo);
            await Task.CompletedTask;
        }

        public async Task<bool> Commit()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public Task Rollback()
        {
            /*
             * Aqui você pode fazer log, avisar a alguém ou algum setor ou processo.
             * Caso você esteja usando ADO com Transaction ou algo similar, você
             * poderá executar o RollBack de verdade.
             * No nosso exemplo, aqui, basta finalizarmos a tarefa e deixar o método
             * como possibilidade de extensão para outros Devs.
             */

            return Task.CompletedTask;
        }

    }
}
