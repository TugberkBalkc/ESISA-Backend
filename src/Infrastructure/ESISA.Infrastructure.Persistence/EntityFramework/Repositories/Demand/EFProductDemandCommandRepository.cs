using ESISA.Core.Application.Interfaces.Repositories;
using ESISA.Core.Domain.Entities;
using ESISA.Infrastructure.Persistence.EntityFramework.Contexts;
using ESISA.Infrastructure.Persistence.EntityFramework.Repositories.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Infrastructure.Persistence.EntityFramework.Repositories.Demand
{
    public class EFProductDemandCommandRepository : EfCommandRepositoryBase<ProductDemand>, IProductDemandCommandRepository
    {
        public EFProductDemandCommandRepository(ESISADbContext dbContext) : base(dbContext)
        {
        }
    }
}
