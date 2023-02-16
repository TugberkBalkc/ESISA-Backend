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
    public class IndividualCustomerIndividualDealerCommentEntityConfiguration : EntityConfigurationBase<IndividualCustomerIndividualDealerComment>
    {
        public override void Configure(EntityTypeBuilder<IndividualCustomerIndividualDealerComment> builder)
        {
            base.Configure(builder);


            builder.ToTable("IndividualCustomerIndividualDealerComments");


            builder.Property(e => e.IndividualCustomerId)
             .HasColumnName("IndividualCustomerId")
             .HasColumnType("uniqueidentifier");

            builder.Property(e => e.IndividualDealerId)
               .HasColumnName("IndividualDealerId")
               .HasColumnType("uniqueidentifier");

            builder.Property(e => e.Title)
                .HasColumnName("Title")
                .HasColumnType("nvarchar(MAX)");

            builder.Property(e => e.Content)
                .HasColumnName("Content")
                .HasColumnType("nvarchar(MAX)");


            builder.HasOne(e => e.IndividualCustomer)
                .WithMany(e => e.IndividualCustomerIndividualDealerComments)
                .HasForeignKey(e => e.IndividualCustomerId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(e => e.IndividualDealer)
                .WithMany(e => e.IndividualCustomerIndividualDealerComments)
                .HasForeignKey(e => e.IndividualDealerId)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
