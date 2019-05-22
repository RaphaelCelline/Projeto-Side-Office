using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SideOffice.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SideOffice.Infra.Data.EntityConfig
{
    public class RentConfiguration : IEntityTypeConfiguration<Rent>
    {
        public void Configure(EntityTypeBuilder<Rent> builder)
        {
            // Relação
            builder.HasOne(c => c.User)
                .WithMany(c => c.Rents);

            builder.HasOne(c => c.Room)
                .WithMany(c => c.Rents);

            // Chave Primaria
            builder.HasKey(p => p.Rent_id);
            builder.Property(p => p.Rent_id)
                .HasColumnType("uniqueidentifier")
                .IsRequired();

            // Demais
            builder.Property(p => p.User_id)
                .HasColumnType("uniqueidentifier")
                .IsRequired();

            builder.Property(p => p.Title)
                .HasColumnType("varchar(50)")
                .IsRequired();

            builder.Property(p => p.Description)
                .HasColumnType("varchar(250)")
                .IsRequired();

            builder.Property(p => p.Start_datetime)
                .HasColumnType("datetime")
                .IsRequired();

            builder.Property(p => p.End_datetime)
               .HasColumnType("datetime")
               .IsRequired();

            builder.Property(p => p.Status)
              .HasColumnType("char(1)")
              .IsRequired();
        }
    }
}
