﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SCM.Domain.Entities;

namespace SCM.Persistence.Mappings
{
    public class AccountMapping : BaseEntityMapping<Account>
    {
        public override void ConfigureDerivedEntityMapping(EntityTypeBuilder<Account> builder)
        {
            builder.Property(x => x.UserId)
                .HasColumnName("CUSTOMER_ID")
                .HasColumnOrder(2);

            builder.Property(x => x.UserName)
                .IsRequired()
                .HasColumnType("nvarchar(10)")
                .HasColumnName("USER_NAME")
                .HasColumnOrder(3);

            builder.Property(x => x.Password)
                .IsRequired()
                .HasColumnType("nvarchar(100)")
                .HasColumnName("PASSWORD")
                .HasColumnOrder(4);

            builder.Property(x => x.LastUserLogin)
                .HasColumnName("LAST_USER_LOGIN")
                .IsRequired(false)
                .HasColumnOrder(5);

            builder.Property(x => x.LastUserId)
                .HasColumnType("nvarchar(50)")
                .HasColumnName("LAST_LOGIN_IP")
                .IsRequired(false)
                .HasColumnOrder(6);

            builder.Property(x => x.Roles)
                .HasColumnName("ROLE_ID")
                .HasColumnOrder(7);

            builder.ToTable("ACCOUNTS");
        }
    }
}