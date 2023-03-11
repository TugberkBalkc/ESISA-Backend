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
    public class ProductDemandEntityConfiguration : EntityConfigurationBase<ProductDemand>
    {
        public override void Configure(EntityTypeBuilder<ProductDemand> builder)
        {
            base.Configure(builder);


            builder.ToTable("ProductDemands");


            builder.Property(e => e.CorporateDealerId)
                   .HasColumnName("CorporateDealerId")
                   .HasColumnType("uniqueidentifier");

            builder.Property(e => e.SenderNote)
                   .HasColumnName("SenderNote")
                   .HasColumnType("nvarchar(MAX)");

            builder.Property(e => e.CategoryId)
                   .HasColumnName("CategoryId")
                   .HasColumnType("uniqueidentifier");

            builder.Property(e => e.ProductName)
                   .HasColumnName("ProductName")
                   .HasColumnType("nvarchar(MAX)");

            builder.HasOne(e => e.CorporateDealer)
                   .WithMany(e => e.ProductDemands)
                   .HasForeignKey(e => e.CorporateDealerId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e=>e.Category)
                   .WithMany(e=>e.ProductDemands)
                   .HasForeignKey(e=>e.CategoryId)
                   .OnDelete(DeleteBehavior.Restrict);
                   
        }
    }
}
