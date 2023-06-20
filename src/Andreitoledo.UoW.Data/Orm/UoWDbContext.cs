﻿using Andreitoledo.UoW.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Andreitoledo.UoW.Data.Orm
{
    internal class UoWDbContext : DbContext
    {
        public UoWDbContext() { }

        public UoWDbContext(DbContextOptions<UoWDbContext> options) 
            : base(options) { }

        public DbSet<Pessoa>? Pessoas { get; set; }
        public DbSet<Voo> Voo { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // onde não tiver setado varchar e a propriedade for do tipo string fica valendo varchar(valor)
            foreach (var property in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetProperties()
                    .Where(p => p.ClrType == typeof(string))))
            {
                //property.Relational().ColumnType = "varchar(100)"; .Net 2.2
                property.SetColumnType("varchar(100)");
            }

            // Todo: Busca os Mapppings de uma vez só
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(UoWDbContext).Assembly);

            // Todo: remover exclusão em cascata
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys())) 
                relationship.DeleteBehavior = DeleteBehavior.ClientNoAction;


            base.OnModelCreating(modelBuilder);
        }

    }
}
