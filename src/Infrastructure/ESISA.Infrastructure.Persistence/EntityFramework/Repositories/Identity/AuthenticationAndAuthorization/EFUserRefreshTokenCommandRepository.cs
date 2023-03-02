using ESISA.Core.Application.Interfaces.Repositories.Identity.AuthenticationAndAuthorization;
using ESISA.Core.Domain.Entities.Identity.AuthenticationAndAuthorization;
using ESISA.Infrastructure.Persistence.EntityFramework.Contexts;
using ESISA.Infrastructure.Persistence.EntityFramework.Repositories.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Infrastructure.Persistence.EntityFramework.Repositories.Identity.AuthenticationAndAuthorization
{
    public class EFUserRefreshTokenCommandRepository : EfCommandRepositoryBase<UserRefreshToken>, IUserRefreshTokenCommandRepository
    {
        public EFUserRefreshTokenCommandRepository(ESISADbContext dbContext) : base(dbContext)
        {
        }
    }
}
