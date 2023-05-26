using ESISA.Core.Application.Interfaces.Repositories.Common;
using ESISA.Core.Application.Utilities.DynamicQuerying.Models;
using ESISA.Core.Domain.Entities;
using System.Linq.Expressions;

namespace ESISA.Core.Application.Interfaces.Repositories
{
    public interface IWholesaleAdvertQueryRepository : IQueryRepository<WholesaleAdvert>
    {
        IQueryable<WholesaleAdvert> GetIncludedByDynamicQuery(DynamicQuery dynamicQuery,
                                     Expression<Func<WholesaleAdvert, bool>> predicate = null,
                                     bool trackingStatus = false);

        IQueryable<WholesaleAdvert> GetWhereIncluded(Expression<Func<WholesaleAdvert, bool>> predicate, bool trackingStatus = false,
                                Func<IQueryable<WholesaleAdvert>, IOrderedQueryable<WholesaleAdvert>> orderBy = null);

        IQueryable<WholesaleAdvert> GetAllIncluded(bool trackingStatus = false,
                                  Func<IQueryable<WholesaleAdvert>, IOrderedQueryable<WholesaleAdvert>> orderBy = null);
    }
}
