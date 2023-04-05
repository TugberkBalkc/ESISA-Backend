using ESISA.Core.Application.Dtos;
using ESISA.Core.Application.Dtos.IndividualStarter;
using ESISA.Core.Application.Dtos.Security.Authentication;
using ESISA.Core.Application.Dtos.Security.Authentication.Registrations;
using ESISA.Core.Application.Dtos.User;
using ESISA.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Interfaces.Services.Authentications
{
    public interface IInternalAuthenticationService
    {
        Task<Token> LoginAsync(UserLoginDto userLoginDto, int tokenLifeTimeInSeconds);

        Task<UserDto> GetUserByEmailAsync(String userEmail);

        Task<IndividualStarterDto> RegisterAsIndividualStarterAsync(RegisterIndividualStarterDto registerIndividualStarterDto);
        Task<CorporateCustomerDto> RegisterAsCorporateCustomerAsync(RegisterCorporateCustomerDto registerCorporateCustomerDto);

        Task<CorporateDealerDto> RegisterAsCorporateDealerAsync(RegisterCorporateDealerDto registerCorporateDealerDto);

        Task<ModeratorDto> RegisterAsCorporateDealerAsync(RegisterModeratorDto registerModeratorDto);
        Task<SupportDto> RegisterAsCorporateDealerAsync(RegisterSupportDto registerSupportDto);
    }
}
