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
        Task<Token> FacebookLoginAsync(String authToken, int tokenLifeTimeInSeconds);
        Task<Token> GoogleLoginAsync(String idToken, int tokenLifeTimeInSeconds);
    }
}
