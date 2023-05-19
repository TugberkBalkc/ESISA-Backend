using ESISA.Core.Application.Constants.Response;
using ESISA.Core.Application.Dtos.Security.Authentication;
using ESISA.Core.Application.Interfaces.Repositories;
using ESISA.Core.Application.Interfaces.Services.Authentications;
using ESISA.Core.Application.Rules.BusinessRules;
using ESISA.Core.Application.Utilities.Response.ContentResponse;
using MediatR;

namespace ESISA.Core.Application.Features.MediatR.Commands.CorporateDealer.LoginAsCorporateDealer
{
    public class LoginAsCorporateDealerCommandHandler : IRequestHandler<LoginAsCorporateDealerCommandRequest, LoginAsCorporateDealerCommandResponse>
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly ICorporateDealerQueryRepository _corporateDealerQueryRepository;
        private readonly IDealerQueryRepository _dealerQueryRepository;
        private readonly IUserQueryRepository _userQueryRepository;
        private readonly CorporateDealerBusinessRules _corporateDealerBusinessRules;
        private readonly UserBusinessRules _userBusinessRules;

        public LoginAsCorporateDealerCommandHandler(IAuthenticationService authenticationService, ICorporateDealerQueryRepository corporateDealerQueryRepository, CorporateDealerBusinessRules corporateDealerBusinessRules, UserBusinessRules userBusinessRules, IDealerQueryRepository dealerQueryRepository, IUserQueryRepository userQueryRepository)
        {
            _authenticationService = authenticationService;
            _corporateDealerQueryRepository = corporateDealerQueryRepository;
            _corporateDealerBusinessRules = corporateDealerBusinessRules;
            _userBusinessRules = userBusinessRules;
            _dealerQueryRepository = dealerQueryRepository;
            _userQueryRepository = userQueryRepository;
        }

        public async Task<LoginAsCorporateDealerCommandResponse> Handle(LoginAsCorporateDealerCommandRequest request, CancellationToken cancellationToken)
        {
            var corporateDealer = await _corporateDealerQueryRepository.GetSingleAsync(e => e.TaxIdentityNumber == request.CorporateDealerLoginDto.CorporateDealerTaxIdentityNumber);

            await _corporateDealerBusinessRules.NullCheck(corporateDealer);

            var dealer = await _dealerQueryRepository.GetByIdAsync(corporateDealer.DealerId);
            var user = await _userQueryRepository.GetByIdAsync(dealer.UserId);
           
            await _corporateDealerBusinessRules.NullCheck(corporateDealer);
            await _userBusinessRules.CheckIfUsersAccountActiveOnLogin(user);

            var token = await _authenticationService.LoginAsCorporateDealerAsync(request.CorporateDealerLoginDto);

            return new LoginAsCorporateDealerCommandResponse(new SuccessfulContentResponse<Token>(token, ResponseTitles.Success, ResponseMessages.LoggedIn, System.Net.HttpStatusCode.OK));
        }
    }

}
