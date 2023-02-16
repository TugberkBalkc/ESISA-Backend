using ESISA.Core.Application.Interfaces.Repositorie;
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
    public class EFCorporateCustomerWholesaleAdvertCommentCommandRepository : EfCommandRepositoryBase<CorporateCustomerWholesaleAdvertComment>, ICorporateCustomerWholesaleAdvertCommentCommandRepository
    {
        public EFCorporateCustomerWholesaleAdvertCommentCommandRepository(ESISADbContext dbContext) : base(dbContext)
        {
        }
    }
}
