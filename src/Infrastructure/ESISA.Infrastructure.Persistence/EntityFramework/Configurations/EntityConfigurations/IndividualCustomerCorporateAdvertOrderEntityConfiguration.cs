using ESISA.Core.Domain.Entities;
using ESISA.Infrastructure.Persistence.EntityFramework.Configurations.EntityConfigurations.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ESISA.Infrastructure.Persistence.EntityFramework.Configurations.EntityConfigurations
{
    public class IndividualCustomerCorporateAdvertOrderEntityConfiguration : EntityConfigurationBase<IndividualCustomerCorporateAdvertOrder>
    {
        public override void Configure(EntityTypeBuilder<IndividualCustomerCorporateAdvertOrder> builder)
        {
            base.Configure(builder);


            builder.ToTable("IndividualCustomerCorporateAdvertOrders");


            builder.Property(e => e.OrderId)
                .HasColumnName("OrderId")
                .HasColumnType("uniqueidentifier");

            builder.Property(e => e.CorporateDealerId)
              .HasColumnName("CorporateDealerId")
              .HasColumnType("uniqueidentifier");

            builder.Property(e => e.IndividualCustomerId)
              .HasColumnName("IndividualCustomerId")
              .HasColumnType("uniqueidentifier");

            builder.Property(e => e.IndividualCustomerAddressId)
              .HasColumnName("IndividualCustomerAddressId")
              .HasColumnType("uniqueidentifier");

            builder.Property(e => e.TotalPrice)
          .HasColumnName("TotalPrice")
          .HasColumnType("decimal(10,2)");

            builder.Property(e => e.DiscountedTotalPrice)
              .HasColumnName("DiscountedTotalPrice")
              .HasColumnType("decimal(10,2)");

            builder.HasOne(e => e.Order)
                .WithOne(e => e.IndividualCustomerCorporateAdvertOrder)
                .HasForeignKey<IndividualCustomerCorporateAdvertOrder>(e => e.OrderId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.CorporateDealer)
           .WithMany(e => e.IndividualCustomerCorporateAdvertOrders)
           .HasForeignKey(e => e.CorporateDealerId)
           .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.IndividualCustomer)
             .WithMany(e => e.IndividualCustomerCorporateAdvertOrders)
             .HasForeignKey(e => e.IndividualCustomerId)
             .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.IndividualCustomerAddress)
           .WithMany(e => e.IndividualCustomerCorporateAdvertOrders)
           .HasForeignKey(e => e.IndividualCustomerAddressId)
           .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(e => e.CorporateAdvertOrderItems);
        }
    }
}
