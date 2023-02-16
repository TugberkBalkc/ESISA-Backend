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
    public class OperationClaimEntityConfiguration : EntityConfigurationBase<OperationClaim>
    {
        public override void Configure(EntityTypeBuilder<OperationClaim> builder)
        {
            base.Configure(builder);


            builder.ToTable("OperationClaims");


            builder.Property(e => e.ClaimName)
                .HasColumnName("ClaimName")
                .HasColumnType("nvarchar(MAX)");


            builder.HasMany(e => e.RoleOperationClaims);
        }
    }
}
