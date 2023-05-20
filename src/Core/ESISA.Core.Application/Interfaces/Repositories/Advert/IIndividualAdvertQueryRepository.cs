using ESISA.Core.Application.Interfaces.Repositories.Common;
using ESISA.Core.Application.Utilities.DynamicQuerying.Models;
using ESISA.Core.Domain.Entities;
using System.Linq.Expressions;

namespace ESISA.Core.Application.Interfaces.Repositories
{
    public interface IIndividualAdvertQueryRepository : IQueryRepository<IndividualAdvert>
    {
        IQueryable<IndividualAdvert> GetIncludedByDynamicQuery(DynamicQuery dynamicQuery,
                                        Expression<Func<IndividualAdvert, bool>> predicate = null,
                                        bool trackingStatus = false);

        IQueryable<IndividualAdvert> GetWhereIncluded(Expression<Func<IndividualAdvert, bool>> predicate, bool trackingStatus = false,
                                Func<IQueryable<IndividualAdvert>, IOrderedQueryable<IndividualAdvert>> orderBy = null);

        IQueryable<IndividualAdvert> GetAllIncluded(bool trackingStatus = false,
                                  Func<IQueryable<IndividualAdvert>, IOrderedQueryable<IndividualAdvert>> orderBy = null);
    }
}
