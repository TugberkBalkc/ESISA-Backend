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
    public class RoleOperationClaimEntityConfiguration : EntityConfigurationBase<RoleOperationClaim>
    {
        public override void Configure(EntityTypeBuilder<RoleOperationClaim> builder)
        {
            base.Configure(builder);


            builder.ToTable("RoleOperationClaims");


            builder.Property(e => e.RoleId)
                .HasColumnName("RoleId")
                .HasColumnType("uniqueidentifier");

             builder.Property(e => e.OperationClaimId)
                .HasColumnName("OperationClaimId")
                .HasColumnType("uniqueidentifier");


            builder.HasOne(e => e.Role)
                .WithMany(e => e.RoleOperationClaims)
                .HasForeignKey(e => e.RoleId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(e => e.OperationClaim)
                .WithMany(e => e.RoleOperationClaims)
                .HasForeignKey(e => e.OperationClaimId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
