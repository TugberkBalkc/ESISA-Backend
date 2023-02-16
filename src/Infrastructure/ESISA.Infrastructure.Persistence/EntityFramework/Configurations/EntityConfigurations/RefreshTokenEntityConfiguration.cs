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
    public class RefreshTokenEntityConfiguration : EntityConfigurationBase<RefreshToken>
    {
        public override void Configure(EntityTypeBuilder<RefreshToken> builder)
        {
            base.Configure(builder);

            builder.ToTable("RefreshTokens");


            builder.Property(e => e.UserId)
                .HasColumnName("UserId")
                .HasColumnType("uniqueidentifier");


            builder.Property(e => e.Token)
                .HasColumnName("Token")
                .HasColumnType("nvarchar(MAX)");

            builder.Property(e => e.ExpirationDate)
               .HasColumnName("ExpirationDate")
               .HasColumnType("datetime");


            builder.HasOne(e => e.User)
                .WithOne(e => e.RefreshToken)
                .HasForeignKey<RefreshToken>(e => e.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
