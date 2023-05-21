using ESISA.Core.Application.Interfaces.Repositories.Common;
using ESISA.Core.Application.Utilities.DynamicQuerying.Models;
using ESISA.Core.Domain.Entities;
using System.Linq.Expressions;

namespace ESISA.Core.Application.Interfaces.Repositories
{
    public interface ICorporateAdvertQueryRepository : IQueryRepository<CorporateAdvert>
    {
        IQueryable<CorporateAdvert> GetIncludedByDynamicQuery(DynamicQuery dynamicQuery,
                                       Expression<Func<CorporateAdvert, bool>> predicate = null,
                                       bool trackingStatus = false);

        IQueryable<CorporateAdvert> GetWhereIncluded(Expression<Func<CorporateAdvert, bool>> predicate, bool trackingStatus = false,
                                Func<IQueryable<CorporateAdvert>, IOrderedQueryable<CorporateAdvert>> orderBy = null);

        IQueryable<CorporateAdvert> GetAllIncluded(bool trackingStatus = false,
                                  Func<IQueryable<CorporateAdvert>, IOrderedQueryable<CorporateAdvert>> orderBy = null);
    }
}
