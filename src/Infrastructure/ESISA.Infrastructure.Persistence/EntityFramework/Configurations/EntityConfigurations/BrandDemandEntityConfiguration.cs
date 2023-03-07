using ESISA.Core.Domain.Entities;
using ESISA.Infrastructure.Persistence.EntityFramework.Configurations.EntityConfigurations.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ESISA.Infrastructure.Persistence.EntityFramework.Configurations.EntityConfigurations
{
    public class BrandDemandEntityConfiguration : EntityConfigurationBase<BrandDemand>
    {
        public override void Configure(EntityTypeBuilder<BrandDemand> builder)
        {
            base.Configure(builder);


            builder.ToTable("BrandDemands");


            builder.Property(e => e.CorporateDealerId)
                   .HasColumnName("CorporateDealerId")
                   .HasColumnType("uniqueidentifier");

            builder.Property(e => e.SenderNote)
                   .HasColumnName("SenderNote")
                   .HasColumnType("nvarchar(MAX)");

            builder.Property(e => e.BrandName)
                   .HasColumnName("BrandName")
                   .HasColumnType("nvarchar(MAX)");

            builder.HasOne(e => e.CorporateDealer)
                   .WithMany(e => e.BrandDemands)
                   .HasForeignKey(e => e.CorporateDealerId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
