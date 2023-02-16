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
    public class CompletedOrderEntityConfiguration : EntityConfigurationBase<CompletedOrder>
    {
        public override void Configure(EntityTypeBuilder<CompletedOrder> builder)
        {
            base.Configure(builder);


            builder.ToTable("CompletedOrders");


            builder.Property(e => e.OrderId)
                .HasColumnName("OrderId")
                .HasColumnType("uniqueidentifier");


            builder.HasOne(e => e.Order)
                .WithOne(e => e.CompletedOrder)
                .HasForeignKey<CompletedOrder>(e => e.OrderId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
