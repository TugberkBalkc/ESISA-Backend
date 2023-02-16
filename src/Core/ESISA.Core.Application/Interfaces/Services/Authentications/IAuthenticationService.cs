using ESISA.Core.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Interfaces.Services.Authentications
{
    public interface IAuthenticationService : IInternalAuthenticationService, IExternalAuthenticationService
    {
        Task ResetPasswordAsync(UserResetPasswordDto userResetPasswordDto);

        Task<bool> VerifyResetTokenAsync(String resetToken, Guid userId);
    }
}