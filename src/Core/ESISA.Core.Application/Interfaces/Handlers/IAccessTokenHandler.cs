using ESISA.Core.Application.Dtos;
using ESISA.Core.Application.Dtos.Security.Authentication;
using ESISA.Core.Application.Dtos.Security.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Interfaces.Handlers
{
    public interface IAccessTokenHandler
    {
        AccessToken CreateAccessToken(Guid userId, String userFirstName, String userLastName, String userEmail, String[] usersRoleNames);
    }
}
