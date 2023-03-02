using ESISA.Core.Domain.Entities.Identity.AuthenticationAndAuthorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Infrastructure.Persistence.EntityFramework.Configurations.EntityConfigurations.Common
{
    public class UserRefreshTokenEntityConfiguration : EntityConfigurationBase<UserRefreshToken>
    {
        public override void Configure(EntityTypeBuilder<UserRefreshToken> builder)
        {
            base.Configure(builder);

            builder.Property(e => e.UserId)
                   .HasColumnName("UserId")
                   .HasColumnType("uniqueidentifier");

            builder.Property(e => e.RefreshTokenCode)
                   .HasColumnName("RefreshTokenCode")
                   .HasColumnType("nvarchar(MAX)");

            builder.Property(e => e.RefreshTokenExpiration)
                   .HasColumnName("RefreshTokenExpiration")
                   .HasColumnType("datetime");

            builder.HasOne(e => e.User)
                   .WithMany(e => e.UserRefreshTokens)
                   .HasForeignKey(e => e.UserId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
