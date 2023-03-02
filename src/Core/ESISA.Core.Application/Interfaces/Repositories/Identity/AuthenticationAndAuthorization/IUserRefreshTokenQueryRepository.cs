using ESISA.Core.Application.Interfaces.Repositories.Common;
using ESISA.Core.Domain.Entities.Identity.AuthenticationAndAuthorization;

namespace ESISA.Core.Application.Interfaces.Repositories.Identity.AuthenticationAndAuthorization
{
    public interface IUserRefreshTokenQueryRepository : IQueryRepository<UserRefreshToken>
    {
    }
}
