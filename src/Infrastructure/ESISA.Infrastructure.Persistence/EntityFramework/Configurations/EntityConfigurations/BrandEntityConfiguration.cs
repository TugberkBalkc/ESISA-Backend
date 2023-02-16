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
    public class BrandEntityConfiguration : EntityConfigurationBase<Brand>
    {
        public override void Configure(EntityTypeBuilder<Brand> builder)
        {
            base.Configure(builder);


            builder.ToTable("Brands");


            builder.Property(e => e.Name)
                   .HasColumnName("Name")
                   .HasColumnType("nvarchar(MAX)");

            builder.Property(e => e.WebsiteUrl)
                   .HasColumnName("WebsiteUrl")
                   .HasColumnType("nvarchar(MAX)");


            builder.HasMany(e => e.BrandPhotoPaths);

            builder.HasMany(e => e.Products);
        }
    }
}
