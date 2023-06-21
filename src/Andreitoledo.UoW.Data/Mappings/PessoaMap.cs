﻿using Andreitoledo.UoW.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Andreitoledo.UoW.Data.Mappings
{
    public class PessoaMap : IEntityTypeConfiguration<Pessoa>
    {
        public void Configure(EntityTypeBuilder<Pessoa> builder)
        {
            builder.HasKey(pk => pk.Id);

            builder.Property(n => n.Nome)
                .HasMaxLength(50)
                .HasColumnType("varchar")
                .IsRequired();

            builder.Property(pk => pk.VooId)
                .IsRequired();
            
            // Relacionamento Redundante. Fica como Didático
            builder.HasOne(x => x.Voo).WithMany(x => x.Pessoas).HasForeignKey(x => x.VooId);

        }
    }
}
