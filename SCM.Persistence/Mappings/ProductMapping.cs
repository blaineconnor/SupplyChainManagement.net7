﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SCM.Domain.Entities;
using System.Numerics;

namespace SCM.Persistence.Mappings
{
    public class ProductMapping : AuditableEntityMapping<Product>
    {
        public override void ConfigureDerivedEntityMapping(EntityTypeBuilder<Product> builder)
        {
            builder.Property(x => x.CategoryId)                
                .HasColumnName("CATEGORY_ID")
                .HasColumnOrder(2);

            builder.Property(x => x.Name)
                .HasColumnName("NAME")
                .HasColumnType("nvarchar(50)")
                .HasColumnOrder(3);

            builder.Property(x => x.Detail)
               .HasColumnName("DETAIL")
               .HasColumnType("nvarchar(100)")
               .HasColumnOrder(4);

            builder.Property(x => x.UnitInStock)
               .HasColumnName("UNIT_IN_STOCK")
               .HasColumnOrder(5);

            builder.Property(x => x.UnitPrice)
               .HasColumnName("UNIT_PRICE")
               .HasColumnOrder(6);

            builder.HasOne(x => x.Categories)
                .WithMany(x => x.Products)
                .HasForeignKey(x => x.CategoryId)
                .HasConstraintName("PRODUCT_CATEGORY_CATEGORY_ID");

            builder.HasMany(e => e.Requests)
                .WithOne(e => e.Product)
                .HasForeignKey(e => e.ProductId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.ToTable("PRODUCTS");
        }
    }
}
