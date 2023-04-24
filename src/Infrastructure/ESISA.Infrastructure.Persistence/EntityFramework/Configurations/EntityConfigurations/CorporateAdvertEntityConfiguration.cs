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
    public class CorporateAdvertEntityConfiguration : EntityConfigurationBase<CorporateAdvert>
    {
        public override void Configure(EntityTypeBuilder<CorporateAdvert> builder)
        {
            base.Configure(builder);


            builder.ToTable("CorporateAdverts");


            builder.Property(e => e.AdvertId)
                .HasColumnName("AdvertId")
                .HasColumnType("uniqueidentifier");

            builder.Property(e => e.CorporateDealerId)
                .HasColumnName("CorporateDealerId")
                .HasColumnType("uniqueidentifier");

            builder.Property(e => e.ProductId)
                .HasColumnName("ProductId")
                .HasColumnType("uniqueidentifier");

            builder.Property(e => e.PurchaseQuantityDiscountId)
                .HasColumnName("PurchaseQuantityDiscountId")
                .HasColumnType("uniqueidentifier");

            builder.Property(e => e.StockAmount)
                .HasColumnName("StockAmount")
                .HasColumnType("int");

            builder.Property(e => e.UnitPrice)
                .HasColumnName("UnitPrice")
                .HasColumnType("decimal(10,2)");

            builder.HasOne(e => e.Advert)
                .WithOne(e => e.CorporateAdvert)
                .HasForeignKey<CorporateAdvert>(e => e.AdvertId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(e => e.CorporateDealer)
                .WithMany(e => e.CorporateAdverts)
                .HasForeignKey(e => e.CorporateDealerId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(e => e.Product)
                .WithMany(e => e.CorporateAdverts)
                .HasForeignKey(e => e.ProductId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.PurchaseQuantityDiscount)
             .WithMany(e => e.CorporateAdverts)
             .HasForeignKey(e => e.PurchaseQuantityDiscountId)
             .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(e => e.IndividualCustomerCorporateAdvertComments);
            builder.HasMany(e => e.IndividualCustomerCorporateAdvertFavorites);
            builder.HasMany(e => e.IndividualCustomerCorporateAdvertVotes);

            builder.HasMany(e => e.CorporateAdvertOrderItems);
        }
    }
}
