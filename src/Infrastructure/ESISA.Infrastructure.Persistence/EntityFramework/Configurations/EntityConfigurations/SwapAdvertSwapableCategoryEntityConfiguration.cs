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
    public class SwapAdvertSwapableCategoryEntityConfiguration : EntityConfigurationBase<SwapAdvertSwapableCategory>
    {
        public override void Configure(EntityTypeBuilder<SwapAdvertSwapableCategory> builder)
        {
            base.Configure(builder);


            builder.ToTable("SwapAdvertSwapableCategories");


            builder.Property(e => e.SwapAdvertId)
                .HasColumnName("SwapAdvertId")
                .HasColumnType("uniqueidentifier");

            builder.Property(e => e.CategoryId)
                .HasColumnName("CategoryId")
                .HasColumnType("uniqueidentifier");


            builder.HasOne(e => e.SwapAdvert)
                .WithMany(e => e.SwapAdvertSwapableCategories)
                .HasForeignKey(e => e.SwapAdvertId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(e => e.Category)
                .WithMany(e => e.SwapAdvertSwapableCategories)
                .HasForeignKey(e => e.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
