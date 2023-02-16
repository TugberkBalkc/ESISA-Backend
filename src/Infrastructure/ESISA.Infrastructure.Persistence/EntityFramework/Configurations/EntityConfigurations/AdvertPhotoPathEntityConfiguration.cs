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
    public class AdvertPhotoPathEntityConfiguration : EntityConfigurationBase<AdvertPhotoPath>
    {
        public override void Configure(EntityTypeBuilder<AdvertPhotoPath> builder)
        {
            base.Configure(builder);


            builder.ToTable("AdvertPhotoPaths");


            builder.Property(e => e.AdvertId)
                .HasColumnName("AdvertId")
                .HasColumnType("uniqueidentifier");

            builder.Property(e => e.PhotoPath)
                .HasColumnName("PhotoPath")
                .HasColumnType("nvarchar(MAX)");


            builder.HasOne(e => e.Advert)
                .WithMany(e => e.AdvertPhotoPaths)
                .HasForeignKey(e => e.AdvertId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
