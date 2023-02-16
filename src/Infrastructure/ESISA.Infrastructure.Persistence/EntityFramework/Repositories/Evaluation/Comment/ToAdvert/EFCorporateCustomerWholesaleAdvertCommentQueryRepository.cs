using ESISA.Core.Application.Interfaces.Repositorie;
using ESISA.Core.Application.Interfaces.Repositories;
using ESISA.Core.Domain.Entities;
using ESISA.Infrastructure.Persistence.EntityFramework.Contexts;
using ESISA.Infrastructure.Persistence.EntityFramework.Repositories.Common;

namespace ESISA.Infrastructure.Persistence.EntityFramework.Repositories
{
    public class EFCorporateCustomerWholesaleAdvertCommentQueryRepository : EfQueryRepositoryBase<CorporateCustomerWholesaleAdvertComment>, ICorporateCustomerWholesaleAdvertCommentQueryRepository
    {
        public EFCorporateCustomerWholesaleAdvertCommentQueryRepository(ESISADbContext dbContext) : base(dbContext)
        {
        }
    }
}
