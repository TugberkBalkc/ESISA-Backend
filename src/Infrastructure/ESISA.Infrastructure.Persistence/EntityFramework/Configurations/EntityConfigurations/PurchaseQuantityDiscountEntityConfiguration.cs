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
    public class PurchaseQuantityDiscountEntityConfiguration : EntityConfigurationBase<PurchaseQuantityDiscount>
    {
        public override void Configure(EntityTypeBuilder<PurchaseQuantityDiscount> builder)
        {
            base.Configure(builder);


            builder.ToTable("PurchaseQuantityDiscounts");


            builder.Property(e => e.Description)
                .HasColumnName("Description")
                .HasColumnType("nvarchar(MAX)");

            builder.Property(e => e.Rate)
             .HasColumnName("Rate")
             .HasColumnType("decimal(4,2)");

            builder.Property(e => e.Deadline)
             .HasColumnName("Deadline")
             .HasColumnType("datetime");

            builder.Property(e => e.IsCombinable)
           .HasColumnName("IsCombinable")
           .HasColumnType("bit");

            builder.Property(e => e.MinimumBuyingQuantity)
          .HasColumnName("MinimumBuyingQuantity")
          .HasColumnType("int");

            builder.Property(e => e.MaximumBuyingQuantity)
           .HasColumnName("MaximumBuyingQuantity")
           .HasColumnType("int");


            builder.HasMany(e => e.CorporateAdverts);
            builder.HasMany(e => e.WholesaleAdverts);
        }
    }
}
