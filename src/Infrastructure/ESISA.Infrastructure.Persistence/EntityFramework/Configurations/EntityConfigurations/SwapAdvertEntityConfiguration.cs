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
    public class SwapAdvertEntityConfiguration : EntityConfigurationBase<SwapAdvert>
    {
        public override void Configure(EntityTypeBuilder<SwapAdvert> builder)
        {
            base.Configure(builder);


            builder.ToTable("SwapAdverts");


            builder.Property(e => e.AdvertId)
               .HasColumnName("AdvertId")
               .HasColumnType("uniqueidentifier");

            builder.Property(e => e.IndividualDealerId)
                .HasColumnName("IndividualDealerId")
                .HasColumnType("uniqueidentifier");

            builder.Property(e => e.ProductId)
                .HasColumnName("ProductId")
                .HasColumnType("uniqueidentifier");


            builder.HasOne(e => e.Advert)
                .WithOne(e => e.SwapAdvert)
                .HasForeignKey<SwapAdvert>(e => e.AdvertId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.IndividualDealer)
                .WithMany(e => e.SwapAdverts)
                .HasForeignKey(e => e.IndividualDealerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.Product)
                .WithMany(e => e.SwapAdverts)
                .HasForeignKey(e => e.ProductId)
                .OnDelete(DeleteBehavior.Restrict);


            builder.HasMany(e => e.SwapAdvertSwapableCategories);

            builder.HasMany(e => e.SwapAdvertSwapableProducts);

        }
    }
}
