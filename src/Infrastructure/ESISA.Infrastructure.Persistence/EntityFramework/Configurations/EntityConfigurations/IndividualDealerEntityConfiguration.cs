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
    public class IndividualDealerEntityConfiguration : EntityConfigurationBase<IndividualDealer>
    {
        public override void Configure(EntityTypeBuilder<IndividualDealer> builder)
        {
            base.Configure(builder);

            builder.ToTable("IndividualDealers");

            builder.Property(e => e.DealerId)
                .HasColumnName("DealerId")
                .HasColumnType("uniqueidentifier");

            builder.HasOne(e => e.Dealer)
           .WithOne(e => e.IndividualDealer)
           .HasForeignKey<IndividualDealer>(e => e.DealerId)
           .OnDelete(DeleteBehavior.Cascade);


            builder.HasMany(e => e.IndividualAdverts);
            builder.HasMany(e => e.SwapAdverts);

            builder.HasMany(e => e.IndividualCustomerIndividualDealerComments);
            builder.HasMany(e => e.IndividualCustomerIndividualDealerVotes);
        }
    }
}
