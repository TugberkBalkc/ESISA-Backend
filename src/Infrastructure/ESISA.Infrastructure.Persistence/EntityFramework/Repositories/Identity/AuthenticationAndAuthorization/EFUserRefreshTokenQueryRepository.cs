using ESISA.Core.Application.Interfaces.Repositories.Identity.AuthenticationAndAuthorization;
using ESISA.Core.Domain.Entities.Identity.AuthenticationAndAuthorization;
using ESISA.Infrastructure.Persistence.EntityFramework.Contexts;
using ESISA.Infrastructure.Persistence.EntityFramework.Repositories.Common;

namespace ESISA.Infrastructure.Persistence.EntityFramework.Repositories.Identity.AuthenticationAndAuthorization
{
    public class EFUserRefreshTokenQueryRepository : EfQueryRepositoryBase<UserRefreshToken>, IUserRefreshTokenQueryRepository
    {
        public EFUserRefreshTokenQueryRepository(ESISADbContext dbContext) : base(dbContext)
        {
        }
    }
}
