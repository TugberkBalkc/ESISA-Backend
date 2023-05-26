using ESISA.Core.Application.Interfaces.Repositories.Common;
using ESISA.Core.Application.Utilities.DynamicQuerying.Models;
using ESISA.Core.Domain.Entities;
using System.Linq.Expressions;

namespace ESISA.Core.Application.Interfaces.Repositories
{
    public interface IAddressQueryRepository : IQueryRepository<Address>
    {
        IQueryable<Address> GetIncludedByDynamicQuery(DynamicQuery dynamicQuery,
                                     Expression<Func<Address, bool>> predicate = null,
                                     bool trackingStatus = false);

        IQueryable<Address> GetWhereIncluded(Expression<Func<Address, bool>> predicate, bool trackingStatus = false,
                                Func<IQueryable<Address>, IOrderedQueryable<Address>> orderBy = null);

        IQueryable<Address> GetAllIncluded(bool trackingStatus = false,
                                  Func<IQueryable<Address>, IOrderedQueryable<Address>> orderBy = null);
    }
}
