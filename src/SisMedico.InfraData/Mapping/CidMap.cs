﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SisMedico.InfraData.Mapping;

public class CidMap : IEntityTypeConfiguration<Cid>
{

    public void Configure(EntityTypeBuilder<Cid> builder)
    {
        builder.HasKey(n => n.Id);

        builder.Property(p => p.Codigo).IsRequired().HasColumnType("varchar(6)")
            .HasColumnName("Codigo");

        builder.Property(e => e.CidInternalId).HasColumnName("CidInternalId");

        builder.Property(c => c.Diagnostico)
            .HasColumnName("Diagnostico").HasColumnType("nvarchar(4000)");


        builder.ToTable("Cid");
    }
}
