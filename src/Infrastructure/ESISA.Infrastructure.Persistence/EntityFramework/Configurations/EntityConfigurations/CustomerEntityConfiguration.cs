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
    public class CustomerEntityConfiguration : EntityConfigurationBase<Customer>
    {
        public override void Configure(EntityTypeBuilder<Customer> builder)
        {
            base.Configure(builder);


            builder.ToTable("Customers");


            builder.Property(e => e.UserId)
                .HasColumnName("UserId")
                .HasColumnType("uniqueidentifier");


            builder.HasOne(e => e.User)
                .WithOne(e => e.Customer)
                .HasForeignKey<Customer>(e => e.UserId);


            builder.HasOne(e => e.CorporateCustomer);

            builder.HasOne(e => e.IndividualCustomer);
        }
    }
}
