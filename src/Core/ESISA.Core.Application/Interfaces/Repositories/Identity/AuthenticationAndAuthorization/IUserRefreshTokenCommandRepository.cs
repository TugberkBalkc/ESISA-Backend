using ESISA.Core.Application.Interfaces.Repositories.Common;
using ESISA.Core.Domain.Entities.Identity.AuthenticationAndAuthorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Interfaces.Repositories.Identity.AuthenticationAndAuthorization
{
    public interface IUserRefreshTokenCommandRepository : ICommandRepository<UserRefreshToken>
    {
    }
}
