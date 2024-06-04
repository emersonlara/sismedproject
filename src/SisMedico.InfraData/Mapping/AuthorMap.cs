using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SisMedico.InfraData.Mapping;

public class AuthorMap : IEntityTypeConfiguration<Author>
{
    public void Configure(EntityTypeBuilder<Author> builder)
    {
        builder.ToTable("Author");
        builder.HasKey(pk => pk.Id);
        builder.Property(n => n.Name).HasMaxLength(50).HasColumnType("varchar(50)")
            .HasColumnName("Name").IsRequired();
        builder.Property(n => n.LastName).HasMaxLength(70).HasColumnType("varchar(70)")
            .HasColumnName("LastName");
        builder.Property(n => n.EmailAddress).HasMaxLength(255).HasColumnType("varchar(255)")
            .HasColumnName("EmailAddress");
        builder.Property(n => n.WebSite).HasMaxLength(255).HasColumnType("varchar(500)")
            .HasColumnName("WebSite");



        builder.OwnsOne(vo => vo.RedesSociais)
            .Property(p => p.Facebook).HasColumnName("Facebook")
            .HasMaxLength(400).HasColumnType("varchar(400)");
        builder.OwnsOne(vo => vo.RedesSociais)
            .Property(p => p.Twitter).HasColumnName("Twitter")
            .HasMaxLength(400).HasColumnType("varchar(400)");
        builder.OwnsOne(vo => vo.RedesSociais)
            .Property(p => p.Linkedin).HasColumnName("Linkedin")
            .HasMaxLength(400).HasColumnType("varchar(400)");


        /*
           public virtual IEnumerable<Tags> Tags { get; set; }             
         */
    }
}
