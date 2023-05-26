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
    public class EFWholesaleAdvertQueryRepository : EfQueryRepositoryBase<WholesaleAdvert>, IWholesaleAdvertQueryRepository
    {
        public EFWholesaleAdvertQueryRepository(ESISADbContext dbContext) : base(dbContext)
        {
        }

        public IQueryable<WholesaleAdvert> GetAllIncluded(bool trackingStatus = false, Func<IQueryable<WholesaleAdvert>, IOrderedQueryable<WholesaleAdvert>> orderBy = null)
        {
            IQueryable<WholesaleAdvert> query = this._dbContext.Set<WholesaleAdvert>();

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

            query = query.Include(e => e.CorporateCustomerWholesaleAdvertComments);

            query = query.Include(e => e.CorporateCustomerWholesaleAdvertFavorites);

            query = query.Include(e => e.CorporateCustomerWholesaleAdvertVotes);

            if (trackingStatus is not true)
                query = query.AsNoTracking();

            if (orderBy is not null)
                query = orderBy(query);

            return query;
        }

        public IQueryable<WholesaleAdvert> GetWhereIncluded(Expression<Func<WholesaleAdvert, bool>> predicate, bool trackingStatus = false, Func<IQueryable<WholesaleAdvert>, IOrderedQueryable<WholesaleAdvert>> orderBy = null)
        {
            IQueryable<WholesaleAdvert> query = this._dbContext.Set<WholesaleAdvert>();

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

            query = query.Include(e => e.CorporateCustomerWholesaleAdvertComments);

            query = query.Include(e => e.CorporateCustomerWholesaleAdvertFavorites);

            query = query.Include(e => e.CorporateCustomerWholesaleAdvertVotes);

            if (predicate is not null)
                query = query.Where(predicate);

            if (trackingStatus is not true)
                query = query.AsNoTracking();

            if (orderBy is not null)
                query = orderBy(query);

            return query;
        }

        public IQueryable<WholesaleAdvert> GetIncludedByDynamicQuery(DynamicQuery dynamicQuery, Expression<Func<WholesaleAdvert, bool>> predicate = null, bool trackingStatus = false)
        {
            IQueryable<WholesaleAdvert> query = this._dbContext.Set<WholesaleAdvert>();

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

            query = query.Include(e => e.CorporateCustomerWholesaleAdvertComments);

            query = query.Include(e => e.CorporateCustomerWholesaleAdvertFavorites);

            query = query.Include(e => e.CorporateCustomerWholesaleAdvertVotes);

            if (trackingStatus is not true)
                query = query.AsNoTracking();

            query = query.ToDynamic<WholesaleAdvert>(dynamicQuery);

            if (predicate is not null)
                query = query.Where(predicate);

            return query;
        }
    }

}
