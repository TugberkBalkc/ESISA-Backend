using ESISA.Core.Application.Interfaces.Repositories;
using ESISA.Core.Application.Utilities.DynamicQuerying.Extensions;
using ESISA.Core.Application.Utilities.DynamicQuerying.Models;
using ESISA.Core.Domain.Entities;
using ESISA.Infrastructure.Persistence.EntityFramework.Contexts;
using ESISA.Infrastructure.Persistence.EntityFramework.Repositories.Common;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ESISA.Infrastructure.Persistence.EntityFramework.Repositories
{
    public class EFAddressQueryRepository : EfQueryRepositoryBase<Address>, IAddressQueryRepository
    {
        public EFAddressQueryRepository(ESISADbContext dbContext) : base(dbContext)
        {
        }

        public IQueryable<Address> GetAllIncluded(bool trackingStatus = false, Func<IQueryable<Address>, IOrderedQueryable<Address>> orderBy = null)
        {
            IQueryable<Address> query = this._dbContext.Set<Address>();

            query = query.Include(e => e.Country);

            query = query.Include(e => e.City);

            query = query.Include(e => e.District);

            query = query.Include(e => e.IndividualCustomerAddresses);

            query = query.Include(e => e.CorporateCustomerAddresses);

            if (trackingStatus is not true)
                query = query.AsNoTracking();

            if (orderBy is not null)
                query = orderBy(query);

            return query;
        }

        public IQueryable<Address> GetIncludedByDynamicQuery(DynamicQuery dynamicQuery, Expression<Func<Address, bool>> predicate = null, bool trackingStatus = false)
        {
            IQueryable<Address> query = this._dbContext.Set<Address>();

            query = query.Include(e => e.Country);

            query = query.Include(e => e.City);

            query = query.Include(e => e.District);

            query = query.Include(e => e.IndividualCustomerAddresses);

            query = query.Include(e => e.CorporateCustomerAddresses);


            if (trackingStatus is not true)
                query = query.AsNoTracking();

            query = query.ToDynamic<Address>(dynamicQuery);

            return query;
        }

        public IQueryable<Address> GetWhereIncluded(Expression<Func<Address, bool>> predicate, bool trackingStatus = false, Func<IQueryable<Address>, IOrderedQueryable<Address>> orderBy = null)
        {
            IQueryable<Address> query = this._dbContext.Set<Address>();

            query = query.Include(e => e.Country);

            query = query.Include(e => e.City);

            query = query.Include(e => e.District);

            query = query.Include(e => e.IndividualCustomerAddresses);

            query = query.Include(e => e.CorporateCustomerAddresses);

            if (trackingStatus is not true)
                query = query.AsNoTracking();

            if (predicate is not null)
                query = query.Where(predicate);

            if (orderBy is not null)
                query = orderBy(query);

            return query;
        }
    }
}
