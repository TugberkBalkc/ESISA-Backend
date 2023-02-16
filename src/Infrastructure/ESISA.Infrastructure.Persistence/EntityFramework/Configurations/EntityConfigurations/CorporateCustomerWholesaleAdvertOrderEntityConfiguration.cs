using ESISA.Core.Domain.Entities;
using ESISA.Infrastructure.Persistence.EntityFramework.Configurations.EntityConfigurations.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ESISA.Infrastructure.Persistence.EntityFramework.Configurations.EntityConfigurations
{
    public class CorporateCustomerWholesaleAdvertOrderEntityConfiguration : EntityConfigurationBase<CorporateCustomerWholesaleAdvertOrder>
    {
        public override void Configure(EntityTypeBuilder<CorporateCustomerWholesaleAdvertOrder> builder)
        {
            base.Configure(builder);


            builder.ToTable("CorporateCustomerWholesaleAdvertOrders");


            builder.Property(e => e.OrderId)
                .HasColumnName("OrderId")
                .HasColumnType("uniqueidentifier");

            builder.Property(e => e.CorporateDealerId)
              .HasColumnName("CorporateDealerId")
              .HasColumnType("uniqueidentifier");

            builder.Property(e => e.CorporateCustomerId)
              .HasColumnName("CorporateCustomerId")
              .HasColumnType("uniqueidentifier");

            builder.Property(e => e.CorporateCustomerAddressId)
              .HasColumnName("CorporateCustomerAddressId")
              .HasColumnType("uniqueidentifier");

            builder.Property(e => e.TotalPrice)
          .HasColumnName("TotalPrice")
          .HasColumnType("decimal(10,2)");

            builder.Property(e => e.DiscountedTotalPrice)
              .HasColumnName("DiscountedTotalPrice")
              .HasColumnType("decimal(10,2)");

            builder.HasOne(e => e.Order)
                .WithOne(e => e.CorporateCustomerWholesaleAdvertOrder)
                .HasForeignKey<CorporateCustomerWholesaleAdvertOrder>(e => e.OrderId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(e => e.CorporateDealer)
           .WithMany(e => e.CorporateCustomerWholesaleAdvertOrders)
           .HasForeignKey(e => e.CorporateDealerId)
           .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(e => e.CorporateCustomer)
             .WithMany(e => e.CorporateCustomerWholesaleAdvertOrders)
             .HasForeignKey(e => e.CorporateCustomerId)
             .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(e => e.CorporateCustomerAddress)
           .WithMany(e => e.CorporateCustomerWholesaleAdvertOrders)
           .HasForeignKey(e => e.CorporateCustomerAddressId)
           .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(e => e.WholesaleAdvertOrderItems);
        }
    }
}
