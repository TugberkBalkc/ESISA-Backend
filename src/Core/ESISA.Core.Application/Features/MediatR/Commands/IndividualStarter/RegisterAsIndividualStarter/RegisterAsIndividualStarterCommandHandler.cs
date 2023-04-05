using ESISA.Core.Application.Constants.Response;
using ESISA.Core.Application.Dtos.IndividualStarter;
using ESISA.Core.Application.Interfaces.Services.Authentications;
using ESISA.Core.Application.Rules.BusinessRules;
using ESISA.Core.Application.Utilities.Response.ContentResponse;
using MediatR;

namespace ESISA.Core.Application.Features.MediatR.Commands.IndividualStarter.RegisterAsIndividualStarter
{
    public class RegisterAsIndividualStarterCommandHandler : IRequestHandler<RegisterAsIndividualStarterCommandRequest, RegisterAsIndividualStarterCommandResponse>
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly IndividualStarterBusinessRules _individualStarterBusinessRules;

        public RegisterAsIndividualStarterCommandHandler
            (IAuthenticationService authenticationService, IndividualStarterBusinessRules individualStarterBusinessRules)
        {
            _authenticationService = authenticationService;
            _individualStarterBusinessRules = individualStarterBusinessRules;
        }

        public async Task<RegisterAsIndividualStarterCommandResponse> Handle(RegisterAsIndividualStarterCommandRequest request, CancellationToken cancellationToken)
        {
            var user = await _authenticationService.GetUserByEmailAsync(request.RegisterIndividualStarterDto.StarterEmail);

            await _individualStarterBusinessRules.ExistsCheck(user);

            var individualStarterDto = await _authenticationService.RegisterAsIndividualStarterAsync(request.RegisterIndividualStarterDto);

            return new RegisterAsIndividualStarterCommandResponse(new SuccessfulContentResponse<IndividualStarterDto>(individualStarterDto, ResponseTitles.Success, ResponseMessages.Registered, System.Net.HttpStatusCode.OK));
        }
    }
}
