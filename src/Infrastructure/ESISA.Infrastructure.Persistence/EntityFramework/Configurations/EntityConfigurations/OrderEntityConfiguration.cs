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
    public class OrderEntityConfiguration : EntityConfigurationBase<Order>
    {
        public override void Configure(EntityTypeBuilder<Order> builder)
        {
            base.Configure(builder);


            builder.ToTable("Orders");

            builder.Property(e => e.UpperOrderPriceDiscountId)
               .HasColumnName("UpperOrderPriceDiscountId")
               .HasColumnType("uniqueidentifier");

            builder.Property(e => e.Description)
                .HasColumnName("Description")
                .HasColumnType("nvarchar(MAX)");

            builder.Property(e => e.Code)
            .HasColumnName("Code")
            .HasColumnType("nvarchar(MAX)");

            builder.Property(e => e.TotalPrice)
            .HasColumnName("TotalPrice")
            .HasColumnType("decimal(10,8)");

            builder.Property(e => e.DiscountedTotalPrice)
           .HasColumnName("DiscountedTotalPrice")
           .HasColumnType("decimal(10,8)");

            builder.HasOne(e => e.UpperOrderPriceDiscount)
                .WithMany(e => e.Orders)
                .HasForeignKey(e => e.UpperOrderPriceDiscountId)
                .OnDelete(DeleteBehavior.Cascade);


            builder.HasOne(e => e.CompletedOrder);
            builder.HasOne(e => e.ReturnedOrder);
            builder.HasOne(e => e.IndividualCustomerCorporateAdvertOrder);
            builder.HasOne(e => e.CorporateCustomerWholesaleAdvertOrder);
        }
    }
}
