using ESISA.Core.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Infrastructure.Persistence.EntityFramework.Configurations.EntityConfigurations.Common
{
    public class EntityConfigurationBase<TEntity> : IEntityTypeConfiguration<TEntity>
        where TEntity : EntityBase
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("Id")
                .HasColumnType("uniqueidentifier")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.CreatedDate)
                .HasColumnName("CreatedDate")
                .HasColumnType("datetime")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.ModifiedDate)
                .HasColumnName("ModifiedDate")
                .HasColumnType("datetime")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.IsActive)
                .HasColumnName("IsActive")
                .HasColumnType("bit")
                .ValueGeneratedOnAdd();
        }
    }
}
