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
    public class IndividualCustomerIndividualAdvertFavoriteEntityConfiguration : EntityConfigurationBase<IndividualCustomerIndividualAdvertFavorite>
    {
        public override void Configure(EntityTypeBuilder<IndividualCustomerIndividualAdvertFavorite> builder)
        {
            base.Configure(builder);


            builder.ToTable("IndividualCustomerIndividualAdvertFavorites");


            builder.Property(e => e.IndividualCustomerId)
                .HasColumnName("IndividualCustomerId")
                .HasColumnType("uniqueidentifier");

            builder.Property(e => e.IndividualAdvertId)
              .HasColumnName("IndividualAdvertId")
              .HasColumnType("uniqueidentifier");


            builder.HasOne(e => e.IndividualCustomer)
                .WithMany(e => e.IndividualCustomerIndividualAdvertFavorites)
                .HasForeignKey(e => e.IndividualCustomerId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(e => e.IndividualAdvert)
                .WithMany(e => e.IndividualCustomerIndividualAdvertFavorites)
                .HasForeignKey(e => e.IndividualAdvertId)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
