using ESISA.Core.Application.Dtos.Security.Authentication;
using ESISA.Core.Application.Dtos.Security.Authentication.Registrations;
using ESISA.Core.Application.Dtos.CorporateCustomer;
using ESISA.Core.Application.Dtos.Security.Authentication.Logins;
using ESISA.Core.Application.Dtos.User;

namespace ESISA.Core.Application.Interfaces.Services.Authentications
{
    public interface IInternalAuthenticationService
    {
        Task<Token> LoginAsStarterAsync(StarterLoginDto starterLoginDto, int tokenLifeTimeInSeconds);
        Task<Token> LoginAsCorporateCustomerAsync(CorporateCustomerLoginDto customerLoginDto, int tokenLifeTimeInSeconds);
        Task<Token> LoginAsCorporateDealerAsync(CorporateDealerLoginDto corporateDealerLoginDto, int tokenLifeTimeInSeconds);
        Task<Token> LoginAsSupportAsync(SupportLoginDto supportLoginDto, int tokenLifeTimeInSeconds);
        Task<Token> LoginAsModeratorAsync(ModeratorLoginDto moderatorLoginDto, int tokenLifeTimeInSeconds);


        Task<UserDto> GetUserByEmailAsync(String userEmail);

        Task<IndividualStarterDto> RegisterAsIndividualStarterAsync(RegisterIndividualStarterDto registerIndividualStarterDto);
        Task<CorporateCustomerDto> RegisterAsCorporateCustomerAsync(RegisterCorporateCustomerDto registerCorporateCustomerDto);

        Task<CorporateDealerDto> RegisterAsCorporateDealerAsync(RegisterCorporateDealerDto registerCorporateDealerDto);

        Task<ModeratorDto> RegisterAsCorporateDealerAsync(RegisterModeratorDto registerModeratorDto);
        Task<SupportDto> RegisterAsCorporateDealerAsync(RegisterSupportDto registerSupportDto);
    }
}
