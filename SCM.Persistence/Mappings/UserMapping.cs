﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SCM.Domain.Entities;

namespace SCM.Persistence.Mappings
{
    public class UserMapping : AuditableEntityMapping<User>
    {
        public override void ConfigureDerivedEntityMapping(EntityTypeBuilder<User> builder)
        {
            builder.Property(x => x.IdentityNumber)
                .HasColumnName("IDENTITY_NUMBER")
                .HasColumnType("nchar(11)")
                .IsRequired()
                .HasColumnOrder(4);

            builder.Property(x => x.Name)
                .HasColumnName("NAME")
                .HasColumnType("nvarchar(30)")
                .IsRequired()
                .HasColumnOrder(5);

            builder.Property(x => x.Surname)
                .HasColumnName("SURNAME")
                .HasColumnType("nvarchar(30)")
                .IsRequired()
                .HasColumnOrder(6);

            builder.Property(x => x.Email)
                .HasColumnName("EMAIL")
                .HasColumnType("nvarchar(150)")
                .IsRequired()
                .HasColumnOrder(7);

            builder.Property(x => x.Phone)
                .HasColumnName("PHONE")
                .HasColumnType("nchar(13)")
                .IsRequired()
                .HasColumnOrder(8);

            builder.Property(x => x.BirthDate)
                .HasColumnName("BIRTHDATE")
                .IsRequired()
                .HasColumnOrder(9);

            builder.ToTable("USERS");
        }
    }
}
