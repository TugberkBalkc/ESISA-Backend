using ESISA.Core.Domain.Entities;
using ESISA.Core.Domain.Entities.Common;
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
    public class AddressEntityConfiguration : EntityConfigurationBase<Address>
    {
        public override void Configure(EntityTypeBuilder<Address> builder)
        {
            base.Configure(builder);


            builder.ToTable("Addresses");


            builder.Property(e => e.CountryId)
                .HasColumnName("CountryId")
                .HasColumnType("uniqueidentifier");

            builder.Property(e => e.CityId)
                .HasColumnName("CityId")
                .HasColumnType("uniqueidentifier");

            builder.Property(e => e.DistrictId)
                .HasColumnName("DistrictId")
                .HasColumnType("uniqueidentifier");

            builder.Property(e => e.PostalCode)
                .HasColumnName("PostalCode")
                .HasColumnType("nvarchar(MAX)");

            builder.Property(e => e.Details)
                .HasColumnName("Details")
                .HasColumnType("nvarchar(MAX)");


            builder.HasOne(e => e.Country)
                .WithMany(e => e.Addresses)
                .HasForeignKey(e => e.CountryId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.City)
                .WithMany(e => e.Addresses)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.District)
                .WithMany(e => e.Addresses)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(e => e.CorporateCustomerAddresses);

            builder.HasMany(e => e.IndividualCustomerAddresses);
        }
    }
}
