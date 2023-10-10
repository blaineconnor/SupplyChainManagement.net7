﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SCM.Domain.Entities;

namespace SCM.Persistence.Mappings
{
    public class OfferMapping : AuditableEntityMapping<Offer>
    {
        public override void ConfigureDerivedEntityMapping(EntityTypeBuilder<Offer> builder)
        {
            builder.Property(x => x.RequestId)
               .HasColumnName("REQUEST_ID")
               .HasColumnOrder(3)
               .IsRequired(); 

            builder.Property(x => x.Amount)
                .HasColumnName("AMOUNT")
                .HasColumnOrder(4)
                .HasColumnType("decimal(18, 2)") 
                .IsRequired();

            builder.Property(x => x.SupplierName)
                .HasColumnName("SUPPLIER_NAME")
                .HasColumnOrder(5)
                .HasMaxLength(255) 
                .IsRequired();

            builder.Property(x => x.SupplierId)
                .HasColumnName("SUPPLIER_ID")
                .HasColumnOrder(6)
                .IsRequired();

            builder.Property(x => x.OfferDate)
                .HasColumnName("OFFER_DATE")
                .HasColumnOrder(7)
                .HasColumnType("datetime") 
                .IsRequired();

            builder.ToTable("OFFERS");
        }
    }
}
