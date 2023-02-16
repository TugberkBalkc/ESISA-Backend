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
    public class SwapAdvertSwapableProductEntityConfiguration : EntityConfigurationBase<SwapAdvertSwapableProduct>
    {
        public override void Configure(EntityTypeBuilder<SwapAdvertSwapableProduct> builder)
        {
            base.Configure(builder);


            builder.ToTable("SwapAdvertSwapableProducts");


            builder.Property(e => e.SwapAdvertId)
                   .HasColumnName("SwapAdvertId")
                   .HasColumnType("uniqueidentifier");

            builder.Property(e => e.ProductId)
                   .HasColumnName("ProductId")
                   .HasColumnType("uniqueidentifier");


            builder.HasOne(e => e.SwapAdvert)
                   .WithMany(e => e.SwapAdvertSwapableProducts)
                   .HasForeignKey(e => e.SwapAdvertId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(e => e.Product)
                   .WithMany(e => e.SwapAdvertSwapableProducts)
                   .HasForeignKey(e => e.ProductId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
