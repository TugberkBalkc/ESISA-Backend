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
    public class EFCorporateAdvertQueryRepository : EfQueryRepositoryBase<CorporateAdvert>, ICorporateAdvertQueryRepository
    {
        public EFCorporateAdvertQueryRepository(ESISADbContext dbContext) : base(dbContext)
        {
        }

        public IQueryable<CorporateAdvert> GetAllIncluded(bool trackingStatus = false, Func<IQueryable<CorporateAdvert>, IOrderedQueryable<CorporateAdvert>> orderBy = null)
        {
            IQueryable<CorporateAdvert> query = this._dbContext.Set<CorporateAdvert>();

            query = query.Include(e => e.Advert);

            query = query.Include(e => e.Product);

            query = query.Include(e => e.Product)
              .ThenInclude(e => e.Category);

            query = query.Include(e => e.Product)
                .ThenInclude(e => e.Brand);

            query = query.Include(e => e.CorporateDealer);

            query = query.Include(e => e.CorporateDealer)
                 .ThenInclude(e => e.Dealer)
                 .ThenInclude(e => e.User);

            query = query.Include(e=>e.PurchaseQuantityDiscount);

            query = query.Include(e => e.IndividualCustomerCorporateAdvertComments);

            query = query.Include(e => e.IndividualCustomerCorporateAdvertFavorites);

            query = query.Include(e => e.IndividualCustomerCorporateAdvertVotes);

            if (trackingStatus is not true)
                query = query.AsNoTracking();

            if (orderBy is not null)
                query = orderBy(query);

            return query;
        }

        public IQueryable<CorporateAdvert> GetIncludedByDynamicQuery(DynamicQuery dynamicQuery, Expression<Func<CorporateAdvert, bool>> predicate = null, bool trackingStatus = false)
        {
            IQueryable<CorporateAdvert> query = this._dbContext.Set<CorporateAdvert>();

            query = query.Include(e => e.Advert);

            query = query.Include(e => e.Product);

            query = query.Include(e => e.Product)
              .ThenInclude(e => e.Category);

            query = query.Include(e => e.Product)
                .ThenInclude(e => e.Brand);

            query = query.Include(e => e.CorporateDealer);

            query = query.Include(e => e.CorporateDealer)
                 .ThenInclude(e => e.Dealer)
                 .ThenInclude(e => e.User);

            query = query.Include(e => e.PurchaseQuantityDiscount);

            query = query.Include(e => e.IndividualCustomerCorporateAdvertComments);

            query = query.Include(e => e.IndividualCustomerCorporateAdvertFavorites);

            query = query.Include(e => e.IndividualCustomerCorporateAdvertVotes);

            if (trackingStatus is not true)
                query = query.AsNoTracking();

            query = query.ToDynamic<CorporateAdvert>(dynamicQuery);

            return query;
        }

        public IQueryable<CorporateAdvert> GetWhereIncluded(Expression<Func<CorporateAdvert, bool>> predicate, bool trackingStatus = false, Func<IQueryable<CorporateAdvert>, IOrderedQueryable<CorporateAdvert>> orderBy = null)
        {
            IQueryable<CorporateAdvert> query = this._dbContext.Set<CorporateAdvert>();

            query = query.Include(e => e.Advert);

            query = query.Include(e => e.Product);

            query = query.Include(e => e.Product)
              .ThenInclude(e => e.Category);

            query = query.Include(e => e.Product)
                .ThenInclude(e => e.Brand);

            query = query.Include(e => e.CorporateDealer);

            query = query.Include(e => e.CorporateDealer)
                 .ThenInclude(e => e.Dealer)
                 .ThenInclude(e => e.User);

            query = query.Include(e => e.PurchaseQuantityDiscount);

            query = query.Include(e => e.IndividualCustomerCorporateAdvertComments);

            query = query.Include(e => e.IndividualCustomerCorporateAdvertFavorites);

            query = query.Include(e => e.IndividualCustomerCorporateAdvertVotes);

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
