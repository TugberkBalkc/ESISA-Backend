using ESISA.Core.Application.Dtos.Security.Authentication;
using ESISA.Core.Application.Dtos.Security.Authentication.Registrations;
using ESISA.Core.Application.Dtos.CorporateCustomer;
using ESISA.Core.Application.Dtos.Security.Authentication.Logins;
using ESISA.Core.Application.Dtos.User;

namespace ESISA.Core.Application.Interfaces.Services.Authentications
{
    public interface IInternalAuthenticationService
    {
        Task<Token> LoginAsStarterAsync(StarterLoginDto starterLoginDto);
        Task<Token> LoginAsCorporateCustomerAsync(CorporateCustomerLoginDto customerLoginDto);
        Task<Token> LoginAsCorporateDealerAsync(CorporateDealerLoginDto corporateDealerLoginDtos);
        Task<Token> LoginAsSupportAsync(SupportLoginDto supportLoginDto);
        Task<Token> LoginAsModeratorAsync(ModeratorLoginDto moderatorLoginDto);


        Task<UserDto> GetUserByEmailAsync(String userEmail);

        Task<IndividualStarterDto> RegisterAsIndividualStarterAsync(RegisterIndividualStarterDto registerIndividualStarterDto);
        Task<CorporateCustomerDto> RegisterAsCorporateCustomerAsync(RegisterCorporateCustomerDto registerCorporateCustomerDto);

        Task<CorporateDealerDto> RegisterAsCorporateDealerAsync(RegisterCorporateDealerDto registerCorporateDealerDto);

        Task<ModeratorDto> RegisterAsModeratorAsync(RegisterModeratorDto registerModeratorDto);
        Task<SupportDto> RegisterAsSupportAsync(RegisterSupportDto registerSupportDto);
    }
}
