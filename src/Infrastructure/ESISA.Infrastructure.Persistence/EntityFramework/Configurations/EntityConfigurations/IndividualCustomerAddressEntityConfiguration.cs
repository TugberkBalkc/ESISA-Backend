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
    public class IndividualCustomerAddressEntityConfiguration : EntityConfigurationBase<IndividualCustomerAddress>
    {
        public override void Configure(EntityTypeBuilder<IndividualCustomerAddress> builder)
        {
            base.Configure(builder);


            builder.ToTable("IndividualCustomerAddresses");


            builder.Property(e => e.IndividualCustomerId)
                .HasColumnName("IndividualCustomerId")
                .HasColumnType("uniqueidentifier");

            builder.Property(e => e.AddressId)
                .HasColumnName("AddressId")
                .HasColumnType("uniqueidentifier");

            builder.Property(e => e.IsResidence)
                .HasColumnName("IsResidence")
                .HasColumnType("bit");


            builder.HasOne(e => e.IndividualCustomer)
                .WithMany(e => e.IndividualCustomerAddresses)
                .HasForeignKey(e => e.IndividualCustomerId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(e => e.Address)
                .WithMany(e => e.IndividualCustomerAddresses)
                .HasForeignKey(e => e.AddressId)
                .OnDelete(DeleteBehavior.Cascade);


            builder.HasMany(e => e.IndividualCustomerCorporateAdvertOrders);
        }
    }
}
