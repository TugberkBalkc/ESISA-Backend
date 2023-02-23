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
    public class ProductEntityConfiguration : EntityConfigurationBase<Product>
    {
        public override void Configure(EntityTypeBuilder<Product> builder)
        {
            base.Configure(builder);


            builder.ToTable("Products");


            builder.Property(e => e.CategoryId)
                   .HasColumnName("CategoryId")
                   .HasColumnType("uniqueidentifier");

            builder.Property(e => e.BrandId)
                   .HasColumnName("BrandId")
                   .HasColumnType("uniqueidentifier");

            builder.Property(e => e.Name)
                 .HasColumnName("Name")
                 .HasColumnType("nvarchar(MAX)");


            builder.HasOne(e => e.Category)
                   .WithMany(e => e.Products)
                   .HasForeignKey(e => e.CategoryId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(e => e.Brand)
              .WithMany(e => e.Products)
              .HasForeignKey(e => e.BrandId)
              .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
