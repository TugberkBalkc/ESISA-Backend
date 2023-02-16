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
    public class CorporateCustomerAddressEntityConfiguration : EntityConfigurationBase<CorporateCustomerAddress>
    {
        public override void Configure(EntityTypeBuilder<CorporateCustomerAddress> builder)
        {
            base.Configure(builder);


            builder.ToTable("CorporateCustomerAddresses");


            builder.Property(e => e.CorporateCustomerId)
                .HasColumnName("CorporateCustomerId")
                .HasColumnType("uniqueidentifier");

            builder.Property(e => e.AddressId)
                .HasColumnName("AddressId")
                .HasColumnType("uniqueidentifier");

            builder.Property(e => e.IsCenterCompany)
                .HasColumnName("IsCenterCompany")
                .HasColumnType("bit");


            builder.HasOne(e=>e.CorporateCustomer)
                .WithMany(e=>e.CorporateCustomerAddresses)
                .HasForeignKey(e=>e.CorporateCustomerId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(e => e.Address)
               .WithMany(e => e.CorporateCustomerAddresses)
               .HasForeignKey(e => e.AddressId)
               .OnDelete(DeleteBehavior.Cascade);


            builder.HasMany(e => e.CorporateCustomerWholesaleAdvertOrders);
        }
    }
}
