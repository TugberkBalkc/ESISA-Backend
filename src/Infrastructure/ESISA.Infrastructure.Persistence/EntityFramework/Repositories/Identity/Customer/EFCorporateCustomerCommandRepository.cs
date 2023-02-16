using ESISA.Core.Application.Interfaces.Repositories;
using ESISA.Core.Domain.Entities;
using ESISA.Infrastructure.Persistence.EntityFramework.Contexts;
using ESISA.Infrastructure.Persistence.EntityFramework.Repositories.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Infrastructure.Persistence.EntityFramework.Repositories
{
    public class EFCorporateCustomerCommandRepository : EfCommandRepositoryBase<CorporateCustomer>, ICorporateCustomerCommandRepository
    {
        public EFCorporateCustomerCommandRepository(ESISADbContext dbContext) : base(dbContext)
        {
        }
    }
}
