using ESISA.Core.Application.Features.MediatR.Commands.OperationClaims.Create;
using ESISA.Core.Application.Features.MediatR.Commands.OperationClaims.Delete;
using ESISA.Core.Application.Features.MediatR.Commands.OperationClaims.DeleteRange;
using ESISA.Core.Application.Features.MediatR.Commands.OperationClaims.Update;
using ESISA.WebAPI.Controllers.Common;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ESISA.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperationClaimsController : CustomControllerBase
    {
        public OperationClaimsController(IHttpContextAccessor httpContextAccessor, IMediator mediator) : base(httpContextAccessor, mediator)
        {
        }


        [HttpPost("CreateOperationClaim")]
        public async Task<IActionResult> CreateOperationClaimAsync([FromBody] CreateOperationClaimCommandRequest createOperationClaimCommandRequest)
        {
            var response = await base._mediator.Send(createOperationClaimCommandRequest);

            return this.ActionResultInstanceByResponse(response.Response);
        }

        [HttpDelete("DeleteOperationClaim")]
        public async Task<IActionResult> DeleteOperationClaimAsync([FromBody] DeleteOperationClaimCommandRequest deleteOperationClaimCommandRequest)
        {
            var response = await base._mediator.Send(deleteOperationClaimCommandRequest);

            return this.ActionResultInstanceByResponse(response.Response);
        }

        [HttpDelete("DeleteRangeOperationClaim")]
        public async Task<IActionResult> DeleteRangeOperationClaimAsync([FromBody] DeleteRangeOperationClaimCommandRequest deleteRangeOperationClaimCommandRequest)
        {
            var response = await base._mediator.Send(deleteRangeOperationClaimCommandRequest);

            return this.ActionResultInstanceByResponse(response.Response);
        }

        [HttpPut("UpdateOperationClaim")]
        public async Task<IActionResult> UpdateOperationClaimAsync([FromBody] UpdateOperationClaimCommandRequest updateOperationClaimCommandRequest)
        {
            var response = await base._mediator.Send(updateOperationClaimCommandRequest);

            return this.ActionResultInstanceByResponse(response.Response);
        }
    }
}
