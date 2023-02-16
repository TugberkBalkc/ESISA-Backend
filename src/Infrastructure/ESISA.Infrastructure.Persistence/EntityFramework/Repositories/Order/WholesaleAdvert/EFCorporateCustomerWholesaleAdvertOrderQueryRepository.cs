﻿using ESISA.Core.Application.Interfaces.Repositories;
using ESISA.Core.Domain.Entities;
using ESISA.Infrastructure.Persistence.EntityFramework.Contexts;
using ESISA.Infrastructure.Persistence.EntityFramework.Repositories.Common;

namespace ESISA.Infrastructure.Persistence.EntityFramework.Repositories
{
    public class EFCorporateCustomerWholesaleAdvertOrderQueryRepository : EfQueryRepositoryBase<CorporateCustomerWholesaleAdvertOrder>, ICorporateCustomerWholesaleAdvertOrderQueryRepository
    {
        public EFCorporateCustomerWholesaleAdvertOrderQueryRepository(ESISADbContext dbContext) : base(dbContext)
        {
        }
    }
}
