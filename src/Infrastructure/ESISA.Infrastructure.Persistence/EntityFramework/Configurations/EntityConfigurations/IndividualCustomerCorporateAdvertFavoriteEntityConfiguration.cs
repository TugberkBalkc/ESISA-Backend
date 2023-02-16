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
    public class IndividualCustomerCorporateAdvertFavoriteEntityConfiguration : EntityConfigurationBase<IndividualCustomerCorporateAdvertFavorite>
    {
        public override void Configure(EntityTypeBuilder<IndividualCustomerCorporateAdvertFavorite> builder)
        {
            base.Configure(builder);


            builder.ToTable("IndividualCustomerCorporateAdvertFavorites");


            builder.Property(e => e.IndividualCustomerId)
                .HasColumnName("IndividualCustomerId")
                .HasColumnType("uniqueidentifier");

            builder.Property(e => e.CorporateAdvertId)
              .HasColumnName("CorporateAdvertId")
              .HasColumnType("uniqueidentifier");


            builder.HasOne(e => e.IndividualCustomer)
                .WithMany(e => e.IndividualCustomerCorporateAdvertFavorites)
                .HasForeignKey(e => e.IndividualCustomerId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(e => e.CorporateAdvert)
                .WithMany(e => e.IndividualCustomerCorporateAdvertFavorites)
                .HasForeignKey(e => e.CorporateAdvertId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
