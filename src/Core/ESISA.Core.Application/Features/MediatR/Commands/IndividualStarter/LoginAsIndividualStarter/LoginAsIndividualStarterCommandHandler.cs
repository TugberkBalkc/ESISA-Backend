using ESISA.Core.Application.Constants.Response;
using ESISA.Core.Application.Dtos.Security.Authentication;
using ESISA.Core.Application.Interfaces.Repositories;
using ESISA.Core.Application.Interfaces.Services.Authentications;
using ESISA.Core.Application.Rules.BusinessRules;
using ESISA.Core.Application.Utilities.Response.ContentResponse;
using MediatR;

namespace ESISA.Core.Application.Features.MediatR.Commands.IndividualStarter.LoginAsIndividualStarter
{
    public class LoginAsIndividualStarterCommandHandler : IRequestHandler<LoginAsIndividualStarterCommandRequest, LoginAsIndividualStarterCommandResponse>
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly IUserQueryRepository _userQueryRepository;
        private readonly UserBusinessRules _userBusinessRules;

        public LoginAsIndividualStarterCommandHandler(IAuthenticationService authenticationService, IUserQueryRepository userQueryRepository, UserBusinessRules userBusinessRules)
        {
            _authenticationService = authenticationService;
            _userQueryRepository = userQueryRepository;
            _userBusinessRules = userBusinessRules;
        }

        public async Task<LoginAsIndividualStarterCommandResponse> Handle(LoginAsIndividualStarterCommandRequest request, CancellationToken cancellationToken)
        {
            var user = await _userQueryRepository.GetSingleAsync(e => e.Email == request.StarterLoginDto.StarterEmail);

            await _userBusinessRules.NullCheck(user);
            await _userBusinessRules.CheckIfUsersAccountActiveOnLogin(user);

            var token = await _authenticationService.LoginAsStarterAsync(request.StarterLoginDto);

            return new LoginAsIndividualStarterCommandResponse(new SuccessfulContentResponse<Token>(token, ResponseTitles.Success, ResponseMessages.LoggedIn, System.Net.HttpStatusCode.OK));
        }
    }
}
