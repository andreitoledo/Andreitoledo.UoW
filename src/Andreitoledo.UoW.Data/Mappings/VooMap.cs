using Andreitoledo.UoW.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Andreitoledo.UoW.Data.Mappings
{
    public class VooMap : IEntityTypeConfiguration<Voo>
    {
        public void Configure(EntityTypeBuilder<Voo> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Codigo)
                .IsRequired()
                .HasMaxLength(40)
                .HasColumnType("varchar");

            builder.Property(x => x.Nota)
                .HasMaxLength(100)
                .IsRequired()
                .HasColumnType("varchar(100)");

            // Relationship
            // um voo para muitas pessoas
            // pessoas para um voo
            builder.HasMany(x => x.Pessoas).WithOne(x => x.Voo).HasForeignKey(fk => fk.VooId);




        }
    }
}
