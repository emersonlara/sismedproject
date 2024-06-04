using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SisMedico.InfraData.Mapping;

public class AgendaEventosMapping : IEntityTypeConfiguration<AgendaEventos>
{
    public void Configure(EntityTypeBuilder<AgendaEventos> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(p => p.PacienteId).IsRequired();
        builder.Property(p => p.MedicoId).IsRequired();
        builder.Property(x => x.Title).IsRequired().HasMaxLength(150);
        builder.Property(x => x.Description).IsRequired().HasMaxLength(300);
        builder.Property(x => x.Color).IsRequired().HasMaxLength(100);
    }
}
