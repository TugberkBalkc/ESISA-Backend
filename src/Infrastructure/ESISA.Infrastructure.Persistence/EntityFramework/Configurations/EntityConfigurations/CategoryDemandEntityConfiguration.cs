using ESISA.Core.Domain.Entities;
using ESISA.Infrastructure.Persistence.EntityFramework.Configurations.EntityConfigurations.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ESISA.Infrastructure.Persistence.EntityFramework.Configurations.EntityConfigurations
{
    public class CategoryDemandEntityConfiguration : EntityConfigurationBase<CategoryDemand>
    {
        public override void Configure(EntityTypeBuilder<CategoryDemand> builder)
        {
            base.Configure(builder);


            builder.ToTable("CategoryDemands");


            builder.Property(e => e.CorporateDealerId)
                   .HasColumnName("CorporateDealerId")
                   .HasColumnType("uniqueidentifier");

            builder.Property(e => e.SenderNote)
                   .HasColumnName("SenderNote")
                   .HasColumnType("nvarchar(MAX)");

            builder.Property(e => e.CategoryName)
                   .HasColumnName("CategoryName")
                   .HasColumnType("nvarchar(MAX)");

            builder.HasOne(e => e.CorporateDealer)
                   .WithMany(e => e.CategoryDemands)
                   .HasForeignKey(e => e.CorporateDealerId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
