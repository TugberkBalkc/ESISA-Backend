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
    public class CountryEntityConfiguration : EntityConfigurationBase<Country>
    {
        public override void Configure(EntityTypeBuilder<Country> builder)
        {
            base.Configure(builder);


            builder.ToTable("Countries");



            builder.Property(e => e.Name)
                .HasColumnName("Name")
                .HasColumnType("nvarchar(MAX)");


            builder.HasMany(e => e.Cities);

            builder.HasMany(e => e.Addresses);
        }
    }
}
