using ESISA.Core.Application.Interfaces.Repositories.Common;
using ESISA.Core.Application.Utilities.DynamicQuerying.Models;
using ESISA.Core.Domain.Entities;
using System.Linq.Expressions;

namespace ESISA.Core.Application.Interfaces.Repositories
{
    public interface ISwapAdvertQueryRepository : IQueryRepository<SwapAdvert>
    {
        IQueryable<SwapAdvert> GetIncludedByDynamicQuery(DynamicQuery dynamicQuery,
                                      Expression<Func<SwapAdvert, bool>> predicate = null,
                                      bool trackingStatus = false);

        IQueryable<SwapAdvert> GetWhereIncluded(Expression<Func<SwapAdvert, bool>> predicate, bool trackingStatus = false,
                                Func<IQueryable<SwapAdvert>, IOrderedQueryable<SwapAdvert>> orderBy = null);

        IQueryable<SwapAdvert> GetAllIncluded(bool trackingStatus = false,
                                  Func<IQueryable<SwapAdvert>, IOrderedQueryable<SwapAdvert>> orderBy = null);
    }

}
