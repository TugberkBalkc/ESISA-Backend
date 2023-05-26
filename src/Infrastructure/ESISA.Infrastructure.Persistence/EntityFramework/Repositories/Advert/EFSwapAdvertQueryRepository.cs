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
    public class EFSwapAdvertQueryRepository : EfQueryRepositoryBase<SwapAdvert>, ISwapAdvertQueryRepository
    {
        public EFSwapAdvertQueryRepository(ESISADbContext dbContext) : base(dbContext)
        {
        }

        public IQueryable<SwapAdvert> GetAllIncluded(bool trackingStatus = false, Func<IQueryable<SwapAdvert>, IOrderedQueryable<SwapAdvert>> orderBy = null)
        {
            IQueryable<SwapAdvert> query = this._dbContext.Set<SwapAdvert>();

            query = query.Include(e => e.Advert);

            query = query.Include(e => e.Product);

            query = query.Include(e => e.Product)
              .ThenInclude(e => e.Category);

            query = query.Include(e => e.Product)
                .ThenInclude(e => e.Brand);
            query = query.Include(e => e.IndividualDealer);

            query = query.Include(e => e.IndividualDealer)
                 .ThenInclude(e => e.Dealer)
                 .ThenInclude(e => e.User)
                 .ThenInclude(e => e.Customer)
                 .ThenInclude(e => e.IndividualCustomer);

            query = query.Include(e => e.SwapAdvertSwapableCategories);

            query = query.Include(e => e.SwapAdvertSwapableProducts);

            if (trackingStatus is not true)
                query = query.AsNoTracking();

            if (orderBy is not null)
                query = orderBy(query);

            return query;
        }

        public IQueryable<SwapAdvert> GetIncludedByDynamicQuery(DynamicQuery dynamicQuery, Expression<Func<SwapAdvert, bool>> predicate = null, bool trackingStatus = false)
        {
            IQueryable<SwapAdvert> query = this._dbContext.Set<SwapAdvert>();

            query = query.Include(e => e.Advert);

            query = query.Include(e => e.Product);

            query = query.Include(e => e.Product)
              .ThenInclude(e => e.Category);

            query = query.Include(e => e.Product)
                .ThenInclude(e => e.Brand);

            query = query.Include(e => e.IndividualDealer);

            query = query.Include(e => e.IndividualDealer)
                 .ThenInclude(e => e.Dealer)
                 .ThenInclude(e => e.User)
                 .ThenInclude(e => e.Customer)
                 .ThenInclude(e => e.IndividualCustomer);

            query = query.Include(e => e.SwapAdvertSwapableCategories);

            query = query.Include(e => e.SwapAdvertSwapableProducts);

            if (trackingStatus is not true)
                query = query.AsNoTracking();

            query = query.ToDynamic<SwapAdvert>(dynamicQuery);

            return query;
        }

        public IQueryable<SwapAdvert> GetWhereIncluded(Expression<Func<SwapAdvert, bool>> predicate, bool trackingStatus = false, Func<IQueryable<SwapAdvert>, IOrderedQueryable<SwapAdvert>> orderBy = null)
        {
            IQueryable<SwapAdvert> query = this._dbContext.Set<SwapAdvert>();

            query = query.Include(e => e.Advert);

            query = query.Include(e => e.Product);

            query = query.Include(e => e.Product)
              .ThenInclude(e => e.Category);

            query = query.Include(e => e.Product)
                .ThenInclude(e => e.Brand);

            query = query.Include(e => e.IndividualDealer);

            query = query.Include(e => e.IndividualDealer)
                 .ThenInclude(e => e.Dealer)
                 .ThenInclude(e => e.User)
                 .ThenInclude(e => e.Customer)
                 .ThenInclude(e => e.IndividualCustomer);

            query = query.Include(e => e.SwapAdvertSwapableCategories);

            query = query.Include(e => e.SwapAdvertSwapableProducts);

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
