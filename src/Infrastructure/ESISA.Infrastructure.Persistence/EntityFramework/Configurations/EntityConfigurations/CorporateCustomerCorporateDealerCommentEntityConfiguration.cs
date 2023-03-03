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
    public class CorporateCustomerCorporateDealerCommentEntityConfiguration : EntityConfigurationBase<CorporateCustomerCorporateDealerComment>
    {
        public override void Configure(EntityTypeBuilder<CorporateCustomerCorporateDealerComment> builder)
        {
            base.Configure(builder);


            builder.ToTable("CorporateCustomerCorporateDealerComments");


            builder.Property(e => e.CorporateCustomerId)
             .HasColumnName("CorporateCustomerId")
             .HasColumnType("uniqueidentifier");

            builder.Property(e => e.CorporateDealerId)
               .HasColumnName("CorporateDealerId")
               .HasColumnType("uniqueidentifier");

            builder.Property(e => e.Title)
                .HasColumnName("Title")
                .HasColumnType("nvarchar(MAX)");

            builder.Property(e => e.Content)
                .HasColumnName("Content")
                .HasColumnType("nvarchar(MAX)");


            builder.HasOne(e => e.CorporateCustomer)
                .WithMany(e => e.CorporateCustomerCorporateDealerComments)
                .HasForeignKey(e => e.CorporateCustomerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.CorporateDealer)
                .WithMany(e => e.CorporateCustomerCorporateDealerComments)
                .HasForeignKey(e => e.CorporateDealerId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
