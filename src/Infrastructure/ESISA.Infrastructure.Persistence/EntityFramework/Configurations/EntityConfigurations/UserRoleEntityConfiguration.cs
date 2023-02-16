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
    public class UserRoleEntityConfiguration : EntityConfigurationBase<UserRole>
    {
        public override void Configure(EntityTypeBuilder<UserRole> builder)
        {
            base.Configure(builder);


            builder.ToTable("UserRoles");


            builder.Property(e => e.UserId)
                .HasColumnName("UserId")
                .HasColumnType("uniqueidentifier");

            builder.Property(e => e.RoleId)
               .HasColumnName("RoleId")
               .HasColumnType("uniqueidentifier");


            builder.HasOne(e => e.User)
                .WithMany(e => e.UserRoles)
                .HasForeignKey(e => e.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(e => e.Role)
                .WithMany(e => e.UserRoles)
                .HasForeignKey(e => e.RoleId)
                .OnDelete(DeleteBehavior.Cascade);



        }
    }
}
