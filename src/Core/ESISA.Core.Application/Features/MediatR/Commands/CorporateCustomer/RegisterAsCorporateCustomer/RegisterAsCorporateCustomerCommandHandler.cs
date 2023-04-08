using ESISA.Core.Application.Constants.Response;
using ESISA.Core.Application.Dtos.CorporateCustomer;
using ESISA.Core.Application.Interfaces.Services.Authentications;
using ESISA.Core.Application.Rules.BusinessRules;
using ESISA.Core.Application.Utilities.Response.ContentResponse;
using MediatR;

namespace ESISA.Core.Application.Features.MediatR.Commands.CorporateCustomer.RegisterAsCorporateCustomer
{
    public class RegisterAsCorporateCustomerCommandHandler : IRequestHandler<RegisterAsCorporateCustomerCommandRequest, RegisterAsCorporateCustomerCommandResponse>
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly CorporateCustomerBusinessRules _corporateCustomerBusinessRules;

        public RegisterAsCorporateCustomerCommandHandler(IAuthenticationService authenticationService, CorporateCustomerBusinessRules corporateCustomerBusinessRules)
        {
            _authenticationService = authenticationService;
            _corporateCustomerBusinessRules = corporateCustomerBusinessRules;
        }

        public async Task<RegisterAsCorporateCustomerCommandResponse> Handle(RegisterAsCorporateCustomerCommandRequest request, CancellationToken cancellationToken)
        {
            var user = await _authenticationService.GetUserByEmailAsync(request.RegisterCorporateCustomerDto.CorporateCustomerEmail);

            await _corporateCustomerBusinessRules.ExistsCheck(user);

            var corporateCustomerDto = await _authenticationService.RegisterAsCorporateCustomerAsync(request.RegisterCorporateCustomerDto);

            return new RegisterAsCorporateCustomerCommandResponse(new SuccessfulContentResponse<CorporateCustomerDto>(corporateCustomerDto, ResponseTitles.Success, ResponseMessages.Registered, System.Net.HttpStatusCode.OK));
        }
    }
}
