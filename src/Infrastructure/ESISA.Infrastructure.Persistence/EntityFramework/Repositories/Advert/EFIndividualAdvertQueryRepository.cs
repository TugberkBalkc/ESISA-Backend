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
    public class EFIndividualAdvertQueryRepository : EfQueryRepositoryBase<IndividualAdvert>, IIndividualAdvertQueryRepository
    {
        public EFIndividualAdvertQueryRepository(ESISADbContext dbContext) : base(dbContext)
        {
        }

        public IQueryable<IndividualAdvert> GetAllIncluded(bool trackingStatus = false, Func<IQueryable<IndividualAdvert>, IOrderedQueryable<IndividualAdvert>> orderBy = null)
        {
            IQueryable<IndividualAdvert> query = this._dbContext.Set<IndividualAdvert>();

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

            query = query.Include(e => e.IndividualCustomerIndividualAdvertFavorites);

            if (trackingStatus is not true)
                query = query.AsNoTracking();

            if (orderBy is not null)
                query = orderBy(query);

            return query;
        }

        public IQueryable<IndividualAdvert> GetWhereIncluded(Expression<Func<IndividualAdvert, bool>> predicate, bool trackingStatus = false, Func<IQueryable<IndividualAdvert>, IOrderedQueryable<IndividualAdvert>> orderBy = null)
        {
            IQueryable<IndividualAdvert> query = this._dbContext.Set<IndividualAdvert>();

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

            query = query.Include(e => e.IndividualCustomerIndividualAdvertFavorites);

            if (predicate is not null)
                query = query.Where(predicate);

            if (trackingStatus is not true)
                query = query.AsNoTracking();

            if (orderBy is not null)
                query = orderBy(query);

            return query;
        }

        public IQueryable<IndividualAdvert> GetIncludedByDynamicQuery(DynamicQuery dynamicQuery, Expression<Func<IndividualAdvert, bool>> predicate = null, bool trackingStatus = false)
        {
            IQueryable<IndividualAdvert> query = this._dbContext.Set<IndividualAdvert>();

            query.Include(e => e.Advert);

            query.Include(e => e.Product);

            query.Include(e => e.Product)
              .ThenInclude(e => e.Category);

            query.Include(e => e.Product)
                .ThenInclude(e => e.Brand);

            query.Include(e => e.IndividualDealer);

            query.Include(e => e.IndividualDealer)
                 .ThenInclude(e => e.Dealer)
                 .ThenInclude(e => e.User)
                 .ThenInclude(e=>e.Customer)
                 .ThenInclude(e=>e.IndividualCustomer);

            query.Include(e => e.IndividualCustomerIndividualAdvertFavorites);

            if (trackingStatus is not true)
                query = query.AsNoTracking();

            query = query.ToDynamic<IndividualAdvert>(dynamicQuery);

            if (predicate is not null)
                query = query.Where(predicate);

            return query;
        }
    }
}
