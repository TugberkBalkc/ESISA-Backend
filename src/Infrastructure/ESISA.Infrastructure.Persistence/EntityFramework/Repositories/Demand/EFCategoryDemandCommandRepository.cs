﻿using ESISA.Core.Application.Interfaces.Repositories.Demand;
using ESISA.Core.Domain.Entities;
using ESISA.Infrastructure.Persistence.EntityFramework.Contexts;
using ESISA.Infrastructure.Persistence.EntityFramework.Repositories.Common;

namespace ESISA.Infrastructure.Persistence.EntityFramework.Repositories.Demand
{
    public class EFCategoryDemandCommandRepository : EfCommandRepositoryBase<CategoryDemand>, ICategoryDemandCommandRepository
    {
        public EFCategoryDemandCommandRepository(ESISADbContext dbContext) : base(dbContext)
        {
        }
    }
}
