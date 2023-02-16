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
    public class AdvertEntityConfiguration : EntityConfigurationBase<Advert>
    {
        public override void Configure(EntityTypeBuilder<Advert> builder)
        {
            base.Configure(builder);


            builder.ToTable("Adverts");


            builder.Property(e => e.Title)
                .HasColumnName("Title")
                .HasColumnType("nvarchar(MAX)");

            builder.Property(e => e.Description)
                .HasColumnName("Description")
                .HasColumnType("nvarchar(MAX)");


            builder.HasMany(e => e.AdvertPhotoPaths);

            builder.HasOne(e => e.CorporateAdvert);
            builder.HasOne(e => e.IndividualAdvert);
            builder.HasOne(e => e.SwapAdvert);
            builder.HasOne(e => e.WholesaleAdvert);
        }
    }
}
