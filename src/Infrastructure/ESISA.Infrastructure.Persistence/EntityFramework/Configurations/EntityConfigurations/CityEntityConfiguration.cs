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
    public class CityEntityConfiguration : EntityConfigurationBase<City>
    {
        public override void Configure(EntityTypeBuilder<City> builder)
        {
            base.Configure(builder);


            builder.ToTable("Cities");



            builder.Property(e => e.CountryId)
                .HasColumnName("CountryId")
                .HasColumnType("uniqueidentifier");

            builder.Property(e => e.Name)
                .HasColumnName("Name")
                .HasColumnType("nvarchar(MAX)");


            builder.HasOne(e => e.Country)
                .WithMany(e => e.Cities)
                .HasForeignKey(e => e.CountryId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);


            builder.HasMany(e => e.Districts);

            builder.HasMany(e => e.Addresses);
        }
    }
}
