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
    public class RoleEntityConfiguration : EntityConfigurationBase<Role>
    {
        public override void Configure(EntityTypeBuilder<Role> builder)
        {
            base.Configure(builder);


            builder.ToTable("Roles");


            builder.Property(e => e.Name)
                .HasColumnName("Name")
                .HasColumnType("nvarchar(MAX)");


            builder.HasMany(e => e.RoleOperationClaims);

            builder.HasMany(e => e.UserRoles);
        }
    }
}
