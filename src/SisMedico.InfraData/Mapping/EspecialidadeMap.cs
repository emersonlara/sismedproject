using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SisMedico.InfraData.Mapping;

public class EspecialidadeMap : IEntityTypeConfiguration<Especialidade>
{
    public void Configure(EntityTypeBuilder<Especialidade> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Descricao).IsRequired().HasColumnType("varchar(80)");

        builder.HasMany(e => e.MedicoEspecialidade)
               .WithOne(me => me.Especialidade)
               .HasForeignKey(me => me.EspecialidadeId)
               .IsRequired();

    }
}
