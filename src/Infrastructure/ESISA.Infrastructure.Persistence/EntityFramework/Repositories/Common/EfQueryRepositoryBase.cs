using ESISA.Core.Application.Interfaces.Repositories.Common;
using ESISA.Core.Application.Utilities.Paging.Extensions;
using ESISA.Core.Domain.Entities.Common;
using ESISA.Infrastructure.Persistence.EntityFramework.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Infrastructure.Persistence.EntityFramework.Repositories.Common
{
    public class EfQueryRepositoryBase<TEntity> : IQueryRepository<TEntity>
        where TEntity : EntityBase
    {
        private readonly ESISADbContext _dbContext;

        public EfQueryRepositoryBase(ESISADbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public DbSet<TEntity> _entities => _dbContext.Set<TEntity>();

        public IQueryable<TEntity> GetAll(bool trackingStatus = false,
                                          Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                                          int pageSize = 0, int pageIndex = 0,
                                          params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> query = this._entities.AsQueryable();

            query = ApplyInclude(query, includes);

            if (orderBy is not null)
                query = orderBy(query);

            if (trackingStatus is not true)
                query = query.AsNoTracking();

            if(pageSize != 0 && pageIndex != 0)
                query = query.ToPaginate<TEntity>(pageSize, pageIndex);

            return query;
        }

        public async Task<TEntity> GetByIdAsync(Guid id,
                                          bool trackingStatus = false,
                                          params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> query = this._entities.AsQueryable();

            query.Where(e => e.Id == id);

            query = ApplyInclude(query, includes);

            if (trackingStatus is not true)
                query = query.AsNoTracking();

            return await query.SingleOrDefaultAsync();
        }

        public async Task<TEntity> GetSingleAsync(Expression<Func<TEntity, bool>> predicate,
                                            bool trackingStatus = false,
                                            params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> query = this._entities.AsQueryable();

            if (predicate is not null)
                query = query.Where(predicate);

            query = ApplyInclude(query, includes);

            if (trackingStatus is not true)
                query = query.AsNoTracking();

            return await query.SingleOrDefaultAsync();
        }

        public IQueryable<TEntity> GetWhere(Expression<Func<TEntity, bool>> predicate,
                                            bool trackingStatus = false,
                                            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                                            int pageSize = 0, int pageIndex = 0,
                                            params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> query = this._entities.AsQueryable();

            if (predicate is not null)
                query = query.Where(predicate);

            query = ApplyInclude(query, includes);

            if (orderBy is not null)
                query = orderBy(query);

            if (trackingStatus is not true)
                query = query.AsNoTracking();

            if (pageSize != 0 && pageIndex != 0)
                query = query.ToPaginate<TEntity>(pageSize, pageIndex);

            return query;
        }

        private static IQueryable<TEntity> ApplyInclude(IQueryable<TEntity> query,
                                                   params Expression<Func<TEntity, object>>[] includes)
        {
            if (includes is not null)
            {
                foreach (var includeItem in includes)
                {
                    query = query.Include(includeItem);
                }
            }

            return query;
        }
    }
}
