using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SisMedico.InfraData.Mapping;

public class TagsMap : IEntityTypeConfiguration<Tags>
{
    public void Configure(EntityTypeBuilder<Tags> builder)
    {
        builder.HasKey(pk => pk.Id);
        builder.Property(p => p.Note).HasColumnName("Note").HasColumnType("nvarchar(MAX)");
        builder.Property(p => p.Tag).IsRequired().HasColumnName("Tag").HasMaxLength(90);
        builder.Property(p => p.SourceAt).IsRequired().HasColumnName("SourceAt").HasColumnType("nvarchar(MAX)");

        builder.ToTable("Tags");

        // Tags N:N Author
    }
}
