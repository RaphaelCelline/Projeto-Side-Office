using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SideOffice.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SideOffice.Infra.Data.EntityConfig
{
    public class RoomConfiguration : IEntityTypeConfiguration<Room>
    {
        public void Configure(EntityTypeBuilder<Room> builder)
        {
            // Chave Primaria
            builder.HasKey(p => p.Room_id);

            builder.Property(p => p.Room_id)
                .HasColumnType("uniqueidentifier")
                .IsRequired();

            // Demais
            builder.Property(p => p.Name)
                .HasColumnType("varchar(50)")
                .IsRequired();

            builder.Property(p => p.Description)
                .HasColumnType("varchar(250)")
                .IsRequired();

            builder.Property(p => p.Seats)
               .HasColumnType("int")
               .IsRequired();

            builder.Property(p => p.Square_meters)
               .HasColumnType("numeric(10, 2)")
               .IsRequired();

            builder.Property(p => p.Hour_price)
              .HasColumnType("decimal(10, 2)")
              .IsRequired();

            builder.Property(p => p.Has_wifi)
              .HasColumnType("bit")
              .IsRequired();

            builder.Property(p => p.Has_ethernet)
              .HasColumnType("bit")
              .IsRequired();

            builder.Property(p => p.Has_tv)
              .HasColumnType("bit")
              .IsRequired();

            builder.Property(p => p.Has_webcam)
              .HasColumnType("bit")
              .IsRequired();

            builder.Property(p => p.Has_air_conditioning)
             .HasColumnType("bit")
             .IsRequired();

            builder.Property(p => p.Status)
             .HasColumnType("char(1)")
             .IsRequired();
        }
    }
}
