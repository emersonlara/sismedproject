using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SisMedico.InfraData.Mapping;

public class MedicoMap : IEntityTypeConfiguration<Medico>
{
    public void Configure(EntityTypeBuilder<Medico> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Nome).IsRequired().HasColumnType("varchar(80)");
        builder.Property(x => x.Crm).HasColumnType("varchar(35)");
        builder.Property(x => x.DataNascimento).IsRequired();

        builder.HasMany(m => m.MedicoEspecialidade)
               .WithOne(me => me.Medico)
               .HasForeignKey(me => me.MedicoId)
               .IsRequired();

    }
}
