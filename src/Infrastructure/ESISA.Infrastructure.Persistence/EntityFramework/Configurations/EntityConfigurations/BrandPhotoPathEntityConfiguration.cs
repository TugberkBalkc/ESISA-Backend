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
    public class BrandPhotoPathEntityConfiguration : EntityConfigurationBase<BrandPhotoPath>
    {
        public override void Configure(EntityTypeBuilder<BrandPhotoPath> builder)
        {
            base.Configure(builder);


            builder.ToTable("BrandPhotoPaths");


            builder.Property(e => e.BrandId)
                   .HasColumnName("BrandId")
                   .HasColumnType("uniqueidentifier");

            builder.Property(e => e.PhotoPath)
                 .HasColumnName("PhotoPath")
                 .HasColumnType("nvarchar(MAX)");


            builder.HasOne(e => e.Brand)
                   .WithMany(e => e.BrandPhotoPaths)
                   .HasForeignKey(e => e.BrandId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
