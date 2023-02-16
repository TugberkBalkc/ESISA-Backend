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
    public class IndividualAdvertEntityConfiguration : EntityConfigurationBase<IndividualAdvert>
    {
        public override void Configure(EntityTypeBuilder<IndividualAdvert> builder)
        {
            base.Configure(builder);


            builder.ToTable("IndividualAdverts");


            builder.Property(e => e.AdvertId)
                .HasColumnName("AdvertId")
                .HasColumnType("uniqueidentifier");

            builder.Property(e => e.IndividualDealerId)
                .HasColumnName("IndividualDealerId")
                .HasColumnType("uniqueidentifier");

            builder.Property(e => e.ProductId)
                .HasColumnName("ProductId")
                .HasColumnType("uniqueidentifier");

            builder.Property(e => e.Price)
                .HasColumnName("Price")
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.Bargain)
                .HasColumnName("Bargain")
                .HasColumnType("bit");


            builder.HasOne(e => e.Advert)
                .WithOne(e => e.IndividualAdvert)
                .HasForeignKey<IndividualAdvert>(e => e.AdvertId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.IndividualDealer)
                .WithMany(e => e.IndividualAdverts)
                .HasForeignKey(e => e.IndividualDealerId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.Product)
                .WithMany(e => e.IndividualAdverts)
                .HasForeignKey(e => e.ProductId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);


            builder.HasMany(e => e.IndividualCustomerIndividualAdvertFavorites);
        }
    }
}
