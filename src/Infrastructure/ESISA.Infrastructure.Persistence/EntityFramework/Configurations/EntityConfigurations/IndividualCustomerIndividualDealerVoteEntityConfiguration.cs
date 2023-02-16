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
    public class IndividualCustomerIndividualDealerVoteEntityConfiguration : EntityConfigurationBase<IndividualCustomerIndividualDealerVote>
    {
        public override void Configure(EntityTypeBuilder<IndividualCustomerIndividualDealerVote> builder)
        {
            base.Configure(builder);


            builder.ToTable("IndividualCustomerIndividualDealerVotes");


            builder.Property(e => e.IndividualCustomerId)
                .HasColumnName("IndividualCustomerId")
                .HasColumnType("uniqueidentifier");

            builder.Property(e => e.IndividualDealerId)
               .HasColumnName("IndividualDealerId")
               .HasColumnType("uniqueidentifier");


            builder.HasOne(e => e.IndividualCustomer)
                .WithMany(e => e.IndividualCustomerIndividualDealerVotes)
                .HasForeignKey(e => e.IndividualCustomer)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(e => e.IndividualDealer)
                .WithMany(e => e.IndividualCustomerIndividualDealerVotes)
                .HasForeignKey(e => e.IndividualDealerId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
