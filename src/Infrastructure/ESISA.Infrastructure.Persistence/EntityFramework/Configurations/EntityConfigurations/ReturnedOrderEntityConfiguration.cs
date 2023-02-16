using ESISA.Core.Domain.Entities;
using ESISA.Infrastructure.Persistence.EntityFramework.Configurations.EntityConfigurations.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ESISA.Infrastructure.Persistence.EntityFramework.Configurations.EntityConfigurations
{
    public class ReturnedOrderEntityConfiguration : EntityConfigurationBase<ReturnedOrder>
    {
        public override void Configure(EntityTypeBuilder<ReturnedOrder> builder)
        {
            base.Configure(builder);


            builder.ToTable("ReturnedOrders");


            builder.Property(e => e.OrderId)
                .HasColumnName("OrderId")
                .HasColumnType("uniqueidentifier");

            builder.Property(e => e.ReasonDescripton)
                .HasColumnName("ReasonDescripton")
                .HasColumnType("nvarchar(MAX)");


            builder.HasOne(e => e.Order)
                .WithOne(e => e.ReturnedOrder)
                .HasForeignKey<ReturnedOrder>(e => e.OrderId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
