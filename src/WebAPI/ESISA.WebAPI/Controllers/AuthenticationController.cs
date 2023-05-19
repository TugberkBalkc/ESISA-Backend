using ESISA.Core.Application.Features.MediatR.Commands.CorporateCustomer.LoginAsCorporateCustomer;
using ESISA.Core.Application.Features.MediatR.Commands.CorporateCustomer.RegisterAsCorporateCustomer;
using ESISA.Core.Application.Features.MediatR.Commands.CorporateDealer.LoginAsCorporateDealer;
using ESISA.Core.Application.Features.MediatR.Commands.CorporateDealer.RegisterAsCorporateDealer;
using ESISA.Core.Application.Features.MediatR.Commands.IndividualStarter.LoginAsIndividualStarter;
using ESISA.Core.Application.Features.MediatR.Commands.IndividualStarter.RegisterAsIndividualStarter;
using ESISA.WebAPI.Controllers.Common;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ESISA.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : CustomControllerBase
    {
        public AuthenticationController(IHttpContextAccessor httpContextAccessor, IMediator mediator) : base(httpContextAccessor, mediator)
        {
        }

        [HttpPost("LoginAsIndividualStarter")]
        public async Task<IActionResult> LoginAsIndividualStarterAsync([FromBody] LoginAsIndividualStarterCommandRequest loginAsIndividualStarterCommandRequest)
        {
            var response = await _mediator.Send(loginAsIndividualStarterCommandRequest);

            return base.ActionResultInstanceByResponse(response.Response);
        }

        [HttpPost("LoginAsCorporateCustomer")]
        public async Task<IActionResult> RegisterAsCorporateCustomerAsync([FromBody] LoginAsCorporateCustomerCommandRequest loginAsCorporateCustomerCommandRequest)
        {
            var response = await _mediator.Send(loginAsCorporateCustomerCommandRequest);

            return base.ActionResultInstanceByResponse(response.Response);
        }

        [HttpPost("LoginAsCorporateDealer")]
        public async Task<IActionResult> LoginAsCorporateDealerAsync([FromBody] LoginAsCorporateDealerCommandRequest loginAsCorporateDealerCommandRequest)
        {
            var response = await _mediator.Send(loginAsCorporateDealerCommandRequest);

            return base.ActionResultInstanceByResponse(response.Response);
        }

        [HttpPost("RegisterAsIndividualStarter")]
        public async Task<IActionResult> RegisterAsIndividualStarterAsync([FromBody] RegisterAsIndividualStarterCommandRequest registerAsIndividualStarterCommandRequest)
        {
            var response = await _mediator.Send(registerAsIndividualStarterCommandRequest);

            return base.ActionResultInstanceByResponse(response.Response);
        }

        [HttpPost("RegisterAsCorporateCustomer")]
        public async Task<IActionResult> RegisterAsCorporateCustomerAsync([FromBody] RegisterAsCorporateCustomerCommandRequest registerAsCorporateCustomerCommandRequest)
        {
            var response = await _mediator.Send(registerAsCorporateCustomerCommandRequest);

            return base.ActionResultInstanceByResponse(response.Response);
        }

        [HttpPost("RegisterAsCorporateDealer")]
        public async Task<IActionResult> RegisterAsCorporateDealerAsync([FromBody] RegisterAsCorporateDealerCommandRequest registerAsCorporateDealerCommandRequest)
        {
            var response = await _mediator.Send(registerAsCorporateDealerCommandRequest);

            return base.ActionResultInstanceByResponse(response.Response);
        }
    }
}
