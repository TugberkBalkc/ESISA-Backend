using ESISA.Core.Application.Interfaces.Repositories.Common;
using ESISA.Core.Domain.Entities.Common;
using ESISA.Infrastructure.Persistence.EntityFramework.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Infrastructure.Persistence.EntityFramework.Repositories.Common
{
    public class EfCommandRepositoryBase<TEntity> : ICommandRepository<TEntity>
        where TEntity : EntityBase
    {
        private readonly ESISADbContext _dbContext;

        public EfCommandRepositoryBase(ESISADbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public DbSet<TEntity> _entities => _dbContext.Set<TEntity>();

        public async Task<bool> AddAsync(TEntity entity)
        {

            EntityEntry<TEntity> entityEntry = await this._entities.AddAsync(entity);

            return entityEntry.State == EntityState.Added
                ? true
                : false;
        }

        public async Task<bool> AddRangeAsync(List<TEntity> entities)
        {
            await this._entities.AddRangeAsync(entities);

            return true;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            TEntity entity = await this._entities.FindAsync(id);

            return this.Delete(entity);
        }

        public bool Delete(TEntity entity)
        {
            EntityEntry<TEntity> entityEntry = this._entities.Remove(entity);

            return entityEntry.State == EntityState.Deleted
                ? true
                : false;
        }

        public bool DeleteRange(List<TEntity> entities)
        {
            this._entities.RemoveRange(entities);

            return true;
        }

        public void Dispose()
        {
            this._dbContext.Dispose();
        }

        public bool Update(TEntity entity)
        {
            EntityEntry<TEntity> entityEntry = this._entities.Update(entity);

            return entityEntry.State == EntityState.Modified
              ? true
              : false;
        }

        public bool UpdateRange(List<TEntity> entities)
        {
            this._entities.UpdateRange(entities);

            return true;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await this._dbContext.SaveChangesAsync();
        }

    }
}
