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
    public class CorporateCustomerWholesaleAdvertFavoriteEntityConfiguration : EntityConfigurationBase<CorporateCustomerWholesaleAdvertFavorite>
    {
        public override void Configure(EntityTypeBuilder<CorporateCustomerWholesaleAdvertFavorite> builder)
        {
            base.Configure(builder);


            builder.ToTable("CorporateCustomerWholesaleAdvertFavorites");


            builder.Property(e => e.CorporateCustomerId)
                .HasColumnName("CorporateCustomerId")
                .HasColumnType("uniqueidentifier");

            builder.Property(e => e.WholesaleAdvertId)
              .HasColumnName("WholesaleAdvertId")
              .HasColumnType("uniqueidentifier");

            
            builder.HasOne(e=>e.CorporateCustomer)
                .WithMany(e=>e.CorporateCustomerWholesaleAdvertFavorites)
                .HasForeignKey(e=>e.CorporateCustomerId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(e => e.WholesaleAdvert)
                .WithMany(e => e.CorporateCustomerWholesaleAdvertFavorites)
                .HasForeignKey(e => e.WholesaleAdvertId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
