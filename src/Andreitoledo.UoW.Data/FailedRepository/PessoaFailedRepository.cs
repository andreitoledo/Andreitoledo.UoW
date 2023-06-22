﻿using Andreitoledo.UoW.Data.FailedRepository;
using Andreitoledo.UoW.Data.Orm;
using Andreitoledo.UoW.Domain;

public class PessoaFailedRepository : IPessoaFailedRepository
{
    private readonly UoWDbContext _context;

    public PessoaFailedRepository(UoWDbContext context)
    {
        _context = context;
    }

    public async Task AdicionarSeAoVoo(Pessoa pessoa)
    {
        await _context.Set<Pessoa>().AddAsync(pessoa);
        await _context.SaveChangesAsync();
    }
}
