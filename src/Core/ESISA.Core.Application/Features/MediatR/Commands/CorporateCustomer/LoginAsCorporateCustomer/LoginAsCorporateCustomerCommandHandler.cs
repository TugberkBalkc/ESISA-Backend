using ESISA.Core.Application.Constants.Response;
using ESISA.Core.Application.Dtos.Security.Authentication;
using ESISA.Core.Application.Interfaces.Repositories;
using ESISA.Core.Application.Interfaces.Services.Authentications;
using ESISA.Core.Application.Rules.BusinessRules;
using ESISA.Core.Application.Utilities.Response.ContentResponse;
using MediatR;

namespace ESISA.Core.Application.Features.MediatR.Commands.CorporateCustomer.LoginAsCorporateCustomer
{
    public class LoginAsCorporateCustomerCommandHandler : IRequestHandler<LoginAsCorporateCustomerCommandRequest, LoginAsCorporateCustomerCommandResponse>
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly IUserQueryRepository _userQueryRepository;
        private readonly ICorporateCustomerQueryRepository _corporateCustomerQueryRepository;
        private readonly ICustomerQueryRepository _customerQueryRepository;
        private readonly CorporateCustomerBusinessRules _corporateCustomerBusinessRules;
        private readonly UserBusinessRules _userBusinessRules;

        public LoginAsCorporateCustomerCommandHandler(IAuthenticationService authenticationService, IUserQueryRepository userQueryRepository, ICorporateCustomerQueryRepository corporateCustomerQueryRepository, ICustomerQueryRepository customerQueryRepository, CorporateCustomerBusinessRules corporateCustomerBusinessRules, UserBusinessRules userBusinessRules)
        {
            _authenticationService = authenticationService;
            _userQueryRepository = userQueryRepository;
            _corporateCustomerQueryRepository = corporateCustomerQueryRepository;
            _customerQueryRepository = customerQueryRepository;

            _corporateCustomerBusinessRules = corporateCustomerBusinessRules;
            _userBusinessRules = userBusinessRules;
        }

        public async Task<LoginAsCorporateCustomerCommandResponse> Handle(LoginAsCorporateCustomerCommandRequest request, CancellationToken cancellationToken)
        {
            var corporateCustomer = await _corporateCustomerQueryRepository.GetSingleAsync(e => e.TaxIdentityNumber == request.CorporateCustomerLoginDto.CorporateCustomerTaxIdentityNumber);

            await _corporateCustomerBusinessRules.NullCheck(corporateCustomer);

            var customer = await _customerQueryRepository.GetByIdAsync(corporateCustomer.Id);
            var user = await _userQueryRepository.GetByIdAsync(customer.UserId);

            await _corporateCustomerBusinessRules.NullCheck(corporateCustomer);
            await _userBusinessRules.CheckIfUsersAccountActiveOnLogin(user);

            var token = await _authenticationService.LoginAsCorporateCustomerAsync(request.CorporateCustomerLoginDto);

            return new LoginAsCorporateCustomerCommandResponse(new SuccessfulContentResponse<Token>(token, ResponseTitles.Success, ResponseMessages.LoggedIn, System.Net.HttpStatusCode.OK));
        }
    }
}
