using ESISA.Core.Application.Interfaces.Repositories;
using ESISA.Core.Domain.Entities;   
using ESISA.Infrastructure.Persistence.EntityFramework.Contexts;
using ESISA.Infrastructure.Persistence.EntityFramework.Repositories.Common;

namespace ESISA.Infrastructure.Persistence.EntityFramework.Repositories.Demand
{
    public class EFBrandDemandQueryRepository : EfQueryRepositoryBase<BrandDemand>, IBrandDemandQueryRepository
    {
        public EFBrandDemandQueryRepository(ESISADbContext dbContext) : base(dbContext)
        {
        }
    }
}
