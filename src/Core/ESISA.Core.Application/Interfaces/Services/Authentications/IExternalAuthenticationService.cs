using ESISA.Core.Application.Dtos.Security.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Interfaces.Services.Authentications
{
    public interface IExternalAuthenticationService
    {
        Task<AccessToken> FacebookLoginAsync(String authToken, int tokenLifeTimeInSeconds);
        Task<AccessToken> GoogleLoginAsync(String idToken, int tokenLifeTimeInSeconds);
    }
}
