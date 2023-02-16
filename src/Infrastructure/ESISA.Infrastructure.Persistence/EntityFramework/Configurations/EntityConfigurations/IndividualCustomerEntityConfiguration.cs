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
    public class IndividualCustomerEntityConfiguration : EntityConfigurationBase<IndividualCustomer>
    {
        public override void Configure(EntityTypeBuilder<IndividualCustomer> builder)
        {
            base.Configure(builder);


            builder.ToTable("IndividualCustomers");


            builder.Property(e => e.CustomerId)
                .HasColumnName("CustomerId")
                .HasColumnType("uniqueidentifier");

            builder.Property(e => e.FirstName)
                .HasColumnType("FirstName")
                .HasColumnType("nvarchar(MAX)");

            builder.Property(e => e.LastName)
                .HasColumnType("LastName")
                .HasColumnType("nvarchar(MAX)");

            builder.Property(e => e.NationalIdentity)
                .HasColumnType("NationalIdentity")
                .HasColumnType("nvarchar(MAX)");

            builder.Property(e => e.DateOfBirth)
              .HasColumnType("DateOfBirth")
              .HasColumnType("datetime");


            builder.HasOne(e => e.Customer)
                .WithOne(e => e.IndividualCustomer)
                .HasForeignKey<IndividualCustomer>(e => e.CustomerId)
                .OnDelete(DeleteBehavior.Cascade);


            builder.HasMany(e => e.IndividualCustomerAddresses);

            builder.HasMany(e => e.IndividualCustomerCorporateAdvertComments);

            builder.HasMany(e => e.IndividualCustomerCorporateAdvertFavorites);

            builder.HasMany(e => e.IndividualCustomerCorporateAdvertVotes);

            builder.HasMany(e => e.IndividualCustomerIndividualDealerComments);

            builder.HasMany(e => e.IndividualCustomerIndividualDealerVotes);

            builder.HasMany(e => e.IndividualCustomerIndividualAdvertFavorites);

            builder.HasMany(e => e.IndividualCustomerCorporateAdvertOrders);
        }
    }
}
