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
    public class DistrictEntityConfiguration : EntityConfigurationBase<District>
    {
        public override void Configure(EntityTypeBuilder<District> builder)
        {
            base.Configure(builder);


            builder.ToTable("Districts");


            builder.Property(e => e.CityId)
                .HasColumnName("CityId")
                .HasColumnType("uniqueidentifier");

            builder.Property(e => e.Name)
                .HasColumnName("Name")
                .HasColumnType("nvarchar(MAX)");


            builder.HasOne(e => e.City)
                .WithMany(e => e.Districts)
                .HasForeignKey(e => e.CityId)
                .OnDelete(DeleteBehavior.Cascade);


            builder.HasMany(e => e.Addresses);
        }
    }
}
