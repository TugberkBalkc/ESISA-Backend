using ESISA.Core.Domain.Entities;
using ESISA.Infrastructure.Persistence.EntityFramework.Configurations.EntityConfigurations.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ESISA.Infrastructure.Persistence.EntityFramework.Configurations.EntityConfigurations
{
    public class WholesaleAdvertOrderItemEntityConfiguration : EntityConfigurationBase<WholesaleAdvertOrderItem>
    {
        public override void Configure(EntityTypeBuilder<WholesaleAdvertOrderItem> builder)
        {
            base.Configure(builder);


            builder.ToTable("WholesaleAdvertOrderItems");

            builder.Property(e => e.WholesaleAdvertOrderId)
               .HasColumnName("WholesaleAdvertOrderId")
               .HasColumnType("uniqueidentifier");

            builder.Property(e => e.WholesaleAdvertId)
                .HasColumnName("WholesaleAdvertId")
                .HasColumnType("uniqueidentifier");

            builder.Property(e => e.ProductAmount)
          .HasColumnName("ProductAmount")
          .HasColumnType("int");

            builder.Property(e => e.ProductUnitPrice)
                .HasColumnName("ProductUnitPrice")
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.DiscountedProductUnitPrice)
           .HasColumnName("DiscountedProductUnitPrice")
           .HasColumnType("decimal(10,2)");

            builder.HasOne(e => e.WholesaleAdvertOrder)
                .WithMany(e => e.WholesaleAdvertOrderItems)
                .HasForeignKey(e => e.WholesaleAdvertOrderId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(e => e.WholesaleAdvert)
              .WithMany(e => e.WholesaleAdvertOrderItems)
              .HasForeignKey(e => e.WholesaleAdvertId)
              .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
