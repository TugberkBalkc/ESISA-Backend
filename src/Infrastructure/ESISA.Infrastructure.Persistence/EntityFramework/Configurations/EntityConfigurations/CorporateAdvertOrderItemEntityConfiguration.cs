using ESISA.Core.Domain.Entities;
using ESISA.Infrastructure.Persistence.EntityFramework.Configurations.EntityConfigurations.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Infrastructure.Persistence.EntityFramework.Configurations.EntityConfigurations
{
    public class CorporateAdvertOrderItemEntityConfiguration : EntityConfigurationBase<CorporateAdvertOrderItem>
    {
        public override void Configure(EntityTypeBuilder<CorporateAdvertOrderItem> builder)
        {
            base.Configure(builder);


            builder.ToTable("CorporateAdvertOrderItems");

            builder.Property(e => e.CorporateAdvertOrderId)
               .HasColumnName("CorporateAdvertOrderId")
               .HasColumnType("uniqueidentifier");

            builder.Property(e => e.CorporateAdvertId)
                .HasColumnName("CorporateAdvertId")
                .HasColumnType("uniqueidentifier");

            builder.Property(e => e.ProductAmount)
          .HasColumnName("ProductAmount")
          .HasColumnType("int");

            builder.Property(e => e.ProductUnitPrice)
                .HasColumnName("ProductUnitPrice")
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.DiscountedProductUnitPrice)
           .HasColumnName("DiscountedProductUnitPrice")
           .HasColumnType("decimal(10,2)");

            builder.HasOne(e => e.CorporateAdvertOrder)
                .WithMany(e => e.CorporateAdvertOrderItems)
                .HasForeignKey(e => e.CorporateAdvertOrderId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(e => e.CorporateAdvert)
              .WithMany(e => e.CorporateAdvertOrderItems)
              .HasForeignKey(e => e.CorporateAdvertId)
              .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
