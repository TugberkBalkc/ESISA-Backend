using ESISA.Core.Application.Utilities.DynamicQuerying.Models;
using ESISA.Core.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Interfaces.Repositories.Common
{
    public interface IQueryRepository<TEntity> : IRepository<TEntity>
        where TEntity : EntityBase
    {
        IQueryable<TEntity> GetAll(bool trackingStatus = false,
                                   Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                                   params Expression<Func<TEntity, object>>[] includes);
        IQueryable<TEntity> GetWhere(Expression<Func<TEntity, bool>> predicate,
                                     bool trackingStatus = false,
                                     Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                                     params Expression<Func<TEntity, object>>[] includes);

        IQueryable<TEntity> GetByDynamicQuery(DynamicQuery dynamicQuery,
                                     Expression<Func<TEntity, bool>> predicate = null,
                                     bool trackingStatus = false,
                                     params Expression<Func<TEntity, object>>[] includes);

        Task<TEntity> GetByIdAsync(Guid id,
                                   bool trackingStatus = false,
                                   params Expression<Func<TEntity, object>>[] includes);
        Task<TEntity> GetSingleAsync(Expression<Func<TEntity, bool>> predicate,
                                     bool trackingStatus = false,
                                     params Expression<Func<TEntity, object>>[] includes);

    }
}
