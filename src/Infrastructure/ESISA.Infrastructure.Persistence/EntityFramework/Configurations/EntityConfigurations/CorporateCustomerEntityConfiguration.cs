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
    public class CorporateCustomerEntityConfiguration : EntityConfigurationBase<CorporateCustomer>
    {
        public override void Configure(EntityTypeBuilder<CorporateCustomer> builder)
        {
            base.Configure(builder);


            builder.ToTable("CorporateCustomers");


            builder.Property(e => e.CustomerId)
                .HasColumnName("CustomerId")
                .HasColumnType("uniqueidentifier");


            builder.Property(e => e.CompanyName)
                .HasColumnName("CompanyName")
                .HasColumnType("nvarchar(MAX)");

            builder.Property(e => e.TaxIdentityNumber)
               .HasColumnName("TaxIdentityNumber")
               .HasColumnType("nvarchar(MAX)");


            builder.HasOne(e => e.Customer)
                .WithOne(e => e.CorporateCustomer)
                .HasForeignKey<CorporateCustomer>(e => e.CustomerId)
                .OnDelete(DeleteBehavior.Cascade);


            builder.HasMany(e => e.CorporateCustomerAddresses);

            builder.HasMany(e => e.CorporateCustomerWholesaleAdvertComments);

            builder.HasMany(e => e.CorporateCustomerWholesaleAdvertFavorites);

            builder.HasMany(e => e.CorporateCustomerWholesaleAdvertVotes);

            builder.HasMany(e => e.CorporateCustomerCorporateDealerComments);

            builder.HasMany(e => e.WholesaleAdvertOrders);
        }
    }
}
