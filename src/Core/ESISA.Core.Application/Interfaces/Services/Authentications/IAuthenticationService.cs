using ESISA.Core.Application.Dtos;
using ESISA.Core.Application.Dtos.Security.Authentication.Checkouts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Interfaces.Services.Authentications
{
    public interface IAuthenticationService : IInternalAuthenticationService, IExternalAuthenticationService
    {
        Task StarterPasswordResetAsync(StarterPasswordResetDto starterPasswordResetDto);
        Task CorporateCustomerPasswordResetAsync(CorporateCustomerPasswordResetDto corporateCustomerPasswordResetDto);
        Task CorporateDealerPasswordResetAsync(CorporateDealerPasswordResetDto corporateDealerPasswordResetDto);
        Task SupportPasswordResetAsync(SupportPasswordResetDto supportPasswordResetDto);
        Task ModeratorPasswordResetAsync(ModeratorPasswordResetDto moderatorPasswordResetDto);
    }
}