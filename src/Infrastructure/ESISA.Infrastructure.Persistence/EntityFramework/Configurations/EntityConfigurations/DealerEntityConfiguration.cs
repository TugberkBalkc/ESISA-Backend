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
    public class DealerEntityConfiguration : EntityConfigurationBase<Dealer>
    {
        public override void Configure(EntityTypeBuilder<Dealer> builder)
        {
            base.Configure(builder);


            builder.ToTable("Dealers");


            builder.Property(e => e.UserId)
                .HasColumnName("UserId")
                .HasColumnType("uniqueidentifier");

            builder.Property(e => e.AddressId)
             .HasColumnName("AddressId")
             .HasColumnType("uniqueidentifier");


            builder.HasOne(e => e.User)
                .WithOne(e => e.Dealer)
                .HasForeignKey<Dealer>(e => e.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(e => e.Address)
                .WithOne(e => e.Dealer)
                .HasForeignKey<Dealer>(e => e.AddressId)
                .OnDelete(DeleteBehavior.Cascade);


            builder.HasOne(e => e.CorporateDealer);

            builder.HasOne(e => e.IndividualDealer);
        }
    }
}
