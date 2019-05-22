using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SideOffice.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SideOffice.Infra.Data.EntityConfig
{
    public class UsersConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            // Chave Primaria
            builder.HasKey(p => p.User_id);

            // Demais
            builder.Property(p => p.User_id)
                .HasColumnType("uniqueidentifier")
                .IsRequired();

            builder.Property(p => p.Name)
                .HasColumnType("varchar(50)")
                .IsRequired();

            builder.Property(p => p.Last_name)
                .HasColumnType("varchar(50)")
                .IsRequired();

            builder.Property(p => p.Email)
                .HasColumnType("varchar(150)")
                .IsRequired();

            builder.Property(p => p.Document)
                .HasColumnType("varchar(50)")
                .IsRequired();

            builder.Property(p => p.Password)
                .HasColumnType("varbinary(MAX)")
                .IsRequired();

            builder.Property(p => p.Registration_datetime)
                .HasColumnType("datetime")
                .IsRequired();

            builder.Property(p => p.Country_code)
                .HasColumnType("varchar(3)")
                .IsRequired();

            builder.Property(p => p.Last_login_datetime)
                .HasColumnType("datetime")
                .IsRequired();

            builder.Property(p => p.Status)
                .HasColumnType("char(1)")
                .IsRequired();
        }
    }
}
