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

        [HttpPost("RegisterAsIndividualStarter")]
        public async Task<IActionResult> RegisterAsIndividualStarter([FromBody] RegisterAsIndividualStarterCommandRequest registerAsIndividualStarterCommandRequest)
        {
            var response = await _mediator.Send(registerAsIndividualStarterCommandRequest);

            return base.ActionResultInstanceByResponse(response.Response);
        }
    }
}
