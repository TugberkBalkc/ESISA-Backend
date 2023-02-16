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
    public class UserEntityConfiguration : EntityConfigurationBase<User>
    {
        public override void Configure(EntityTypeBuilder<User> builder)
        {
            base.Configure(builder);


            builder.ToTable("Users");


            builder.Property(e => e.Email)
                .HasColumnName("Email")
                .HasColumnType("nvarchar(MAX)");

            builder.Property(e => e.UserName)
              .HasColumnName("UserName")
              .HasColumnType("nvarchar(MAX)");

            builder.Property(e => e.ContactNumber)
              .HasColumnName("ContactNumber")
              .HasColumnType("nvarchar(MAX)");

            builder.Property(e => e.PasswordHash)
             .HasColumnName("PasswordHash")
             .HasColumnType("varbinary(MAX)");

            builder.Property(e => e.PasswordSalt)
              .HasColumnName("PasswordSalt")
              .HasColumnType("varbinary(MAX)");

            builder.Property(e => e.Status)
                .HasColumnName("Status")
                .HasColumnType("bit");


            builder.HasOne(e => e.Customer);
            builder.HasOne(e => e.Dealer);

            builder.HasMany(e => e.UserRoles);
        }
    }
}
