using ESISA.Core.Application.Interfaces.Repositories;
using ESISA.Core.Domain.Entities;
using ESISA.Infrastructure.Persistence.EntityFramework.Contexts;
using ESISA.Infrastructure.Persistence.EntityFramework.Repositories.Common;

namespace ESISA.Infrastructure.Persistence.EntityFramework.Repositories.Demand
{
    public class EFBrandDemandCommandRepository : EfCommandRepositoryBase<BrandDemand>, IBrandDemandCommandRepository
    {
        public EFBrandDemandCommandRepository(ESISADbContext dbContext) : base(dbContext)
        {
        }
    }
}
