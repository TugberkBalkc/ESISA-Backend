using ESISA.Core.Application.Constants.Response;
using ESISA.Core.Application.Dtos.CorporateCustomer;
using ESISA.Core.Application.Dtos.Security.Authentication.Registrations;
using ESISA.Core.Application.Dtos.User;
using ESISA.Core.Application.Features.MediatR.Commands.CorporateCustomer.RegisterAsCorporateCustomer;
using ESISA.Core.Application.Features.MediatR.Requests.Common;
using ESISA.Core.Application.Interfaces.Services.Authentications;
using ESISA.Core.Application.Rules.BusinessRules;
using ESISA.Core.Application.Utilities.Response.Common;
using ESISA.Core.Application.Utilities.Response.ContentResponse;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Features.MediatR.Commands.CorporateDealer.RegisterAsCorporateDealer
{
    public class RegisterAsCorporateDealerCommandRequest : IRequest<RegisterAsCorporateDealerCommandResponse>
    {
        public RegisterCorporateDealerDto RegisterCorporateDealerDto { get; set; }

        public RegisterAsCorporateDealerCommandRequest()
        {

        }

        public RegisterAsCorporateDealerCommandRequest(RegisterCorporateDealerDto registerCorporateDealerDto)
        {
            RegisterCorporateDealerDto = registerCorporateDealerDto;
        }
    }
    public class RegisterAsCorporateDealerCommandResponse : CommandResponseBase<CorporateDealerDto>
    {
        public RegisterAsCorporateDealerCommandResponse(IContentResponse<CorporateDealerDto> response) : base(response)
        {
        }
    }

    public class RegisterAsCorporateDealerCommandHandler : IRequestHandler<RegisterAsCorporateDealerCommandRequest, RegisterAsCorporateDealerCommandResponse>
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly CorporateDealerBusinessRules corporateDealerBusinessRules;

        public RegisterAsCorporateDealerCommandHandler(IAuthenticationService authenticationService, CorporateDealerBusinessRules corporateDealerBusinessRules)
        {
            _authenticationService = authenticationService;
            this.corporateDealerBusinessRules = corporateDealerBusinessRules;
        }

        public async Task<RegisterAsCorporateDealerCommandResponse> Handle(RegisterAsCorporateDealerCommandRequest request, CancellationToken cancellationToken)
        {
            var user = await _authenticationService.GetUserByEmailAsync(request.RegisterCorporateDealerDto.CorporateDealerEmail);

            await corporateDealerBusinessRules.ExistsCheck(user);

            var corporateDealerDto = await _authenticationService.RegisterAsCorporateDealerAsync(request.RegisterCorporateDealerDto);

            return new RegisterAsCorporateDealerCommandResponse(new SuccessfulContentResponse<CorporateDealerDto>(corporateDealerDto, ResponseTitles.Success, ResponseMessages.Registered, System.Net.HttpStatusCode.OK));
        }
    }
}
