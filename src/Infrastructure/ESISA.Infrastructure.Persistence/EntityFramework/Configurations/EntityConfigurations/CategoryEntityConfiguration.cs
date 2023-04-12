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
    public class CategoryEntityConfiguration : EntityConfigurationBase<Category>
    {
        public override void Configure(EntityTypeBuilder<Category> builder)
        {
            base.Configure(builder);

            builder.ToTable("Categories");

            builder.Property(e => e.ParentId)
                   .HasColumnName("ParentId")
                   .IsRequired(false)
                   .HasColumnType("uniqueidentifier");

            builder.Property(e => e.Name)
                .HasColumnName("Name")
                .HasColumnType("nvarchar(MAX)");

            builder.Property(e => e.Description)
                .HasColumnName("Description")
                .HasColumnType("nvarchar(MAX)");
            
            builder.HasOne(s => s.Parent)
            .WithMany(m => m.Children)
            .HasForeignKey(e => e.ParentId)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(e => e.CategoryPhotoPaths);

            builder.HasMany(e => e.CorporateDealersSalesCategory);

            builder.HasMany(e => e.SwapAdvertSwapableCategories);
        }
    }
}
