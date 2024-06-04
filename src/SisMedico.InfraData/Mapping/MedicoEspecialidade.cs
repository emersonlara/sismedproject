using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SisMedico.InfraData.Mapping;

public class MedicoEspecialidadeMapping : IEntityTypeConfiguration<MedicoEspecialidade>
{
    public void Configure(EntityTypeBuilder<MedicoEspecialidade> builder)
    {
        builder.HasKey(me => new { me.MedicoId, me.EspecialidadeId });

        builder.HasOne(me => me.Medico)
               .WithMany(m => m.MedicoEspecialidade)
               .HasForeignKey(me => me.MedicoId);

        builder.HasOne(me => me.Especialidade)
               .WithMany(e => e.MedicoEspecialidade)
               .HasForeignKey(me => me.EspecialidadeId);
    }
}
