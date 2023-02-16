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
    public class UpperOrderPriceDiscountEntityConfiguration : EntityConfigurationBase<UpperOrderPriceDiscount>
    {
        public override void Configure(EntityTypeBuilder<UpperOrderPriceDiscount> builder)
        {
            base.Configure(builder);

            builder.ToTable("UpperOrderPriceDiscounts");


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

            builder.Property(e => e.MinimumOrderPrice)
                .HasColumnName("MinimumOrderPrice")
                .HasColumnType("decimal(10,2)");

            builder.HasMany(e => e.Orders);
        }
    }
}

