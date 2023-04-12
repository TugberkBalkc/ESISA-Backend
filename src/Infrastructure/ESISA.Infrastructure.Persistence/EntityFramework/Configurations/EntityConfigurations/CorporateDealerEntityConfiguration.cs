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
    public class CorporateDealerEntityConfiguration : EntityConfigurationBase<CorporateDealer>
    {
        public override void Configure(EntityTypeBuilder<CorporateDealer> builder)
        {
            base.Configure(builder);


            builder.ToTable("CorporateDealers");


            builder.Property(e => e.DealerId)
                .HasColumnName("DealerId")
                .HasColumnType("uniqueidentifier");

            builder.Property(e => e.SalesCategoryId)
               .HasColumnName("SalesCategoryId")
               .HasColumnType("uniqueidentifier");

            builder.Property(e => e.CompanyName)
                .HasColumnType("CompanyName")
                .HasColumnType("nvarchar(MAX)");

            builder.Property(e => e.TaxIdentityNumber)
               .HasColumnType("TaxIdentityNumber")
               .HasColumnType("nvarchar(MAX)");

            builder.HasOne(e => e.Address)
                .WithMany(e => e.CorporateDealers)
                .HasForeignKey(e => e.AddressId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(e => e.Category)
                .WithMany(e => e.CorporateDealersSalesCategory)
                .HasForeignKey(e => e.SalesCategoryId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
