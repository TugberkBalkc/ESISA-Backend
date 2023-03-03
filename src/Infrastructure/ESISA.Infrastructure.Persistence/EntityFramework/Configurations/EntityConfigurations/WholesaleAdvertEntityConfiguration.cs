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
    public class WholesaleAdvertEntityConfiguration : EntityConfigurationBase<WholesaleAdvert>
    {
        public override void Configure(EntityTypeBuilder<WholesaleAdvert> builder)
        {
            base.Configure(builder);


            builder.ToTable("WholesaleAdverts");


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

            builder.Property(e => e.MinimumPurchaseAmount)
                .HasColumnName("MinimumPurchaseAmount")
                .HasColumnType("int");

            builder.Property(e => e.MaximumPurchaseAmount)
                .HasColumnName("MaximumPurchaseAmount")
                .HasColumnType("int");

            builder.Property(e => e.PricePerUnit)
                .HasColumnName("PricePerUnit")
                .HasColumnType("decimal(10,2)");
        
            
            builder.HasOne(e=>e.Advert)
                .WithOne(e=>e.WholesaleAdvert)
                .HasForeignKey<WholesaleAdvert>(e=>e.AdvertId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(e => e.CorporateDealer)
                .WithMany(e => e.WholesaleAdverts)
                .HasForeignKey(e => e.CorporateDealerId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(e => e.Product)
                .WithMany(e => e.WholesaleAdverts)
                .HasForeignKey(e => e.ProductId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.PurchaseQuantityDiscount)
              .WithMany(e => e.WholesaleAdverts)
              .HasForeignKey(e => e.PurchaseQuantityDiscountId)
              .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(e => e.CorporateCustomerWholesaleAdvertComments);
            builder.HasMany(e => e.CorporateCustomerWholesaleAdvertFavorites);
            builder.HasMany(e => e.CorporateCustomerWholesaleAdvertVotes);
        }
    }
}
