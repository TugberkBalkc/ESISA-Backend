using ESISA.Core.Application.Interfaces.Repositories;
using ESISA.Core.Application.Interfaces.Repositories.Discount;
using ESISA.Core.Domain.Entities;
using ESISA.Infrastructure.Persistence.EntityFramework.Contexts;
using ESISA.Infrastructure.Persistence.EntityFramework.Repositories.Common;

namespace ESISA.Infrastructure.Persistence.EntityFramework.Repositories
{
    public class EFUpperOrderPriceDiscountCommandRepository : EfCommandRepositoryBase<UpperOrderPriceDiscount>, IUpperOrderPriceDiscountCommandRepository
    {
        public EFUpperOrderPriceDiscountCommandRepository(ESISADbContext dbContext) : base(dbContext)
        {
        }
    }
}
