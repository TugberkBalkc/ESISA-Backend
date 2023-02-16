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
    public class CategoryPhotoPathEntityConfiguration : EntityConfigurationBase<CategoryPhotoPath>
    {
        public override void Configure(EntityTypeBuilder<CategoryPhotoPath> builder)
        {
            base.Configure(builder);


            builder.ToTable("CategoryPhotoPaths");


            builder.Property(e => e.CategoryId)
                .HasColumnName("CategoryId")
                .HasColumnType("uniqueidentifier");

            builder.Property(e => e.PhotoPath)
                .HasColumnName("PhotoPath")
                .HasColumnType("nvarchar(MAX)");


            builder.HasOne(e => e.Category)
                .WithMany(e => e.CategoryPhotoPaths)
                .HasForeignKey(e => e.CategoryId);
        }
    }
}
