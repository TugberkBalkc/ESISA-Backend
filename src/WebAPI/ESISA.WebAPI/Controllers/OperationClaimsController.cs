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

            return response.Response.IsSucceeded == true
                ? Ok(response.Response)
                : BadRequest(response.Response.Title + ":" + response.Response.Message);
        }

        [HttpDelete("DeleteOperationClaim")]
        public async Task<IActionResult> DeleteOperationClaimAsync([FromBody] DeleteOperationClaimCommandRequest deleteOperationClaimCommandRequest)
        {
            var response = await base._mediator.Send(deleteOperationClaimCommandRequest);

            return response.Response.IsSucceeded == true
                ? Ok(response.Response)
                : BadRequest(response.Response.Title + ":" + response.Response.Message);
        }

        [HttpDelete("DeleteRangeOperationClaim")]
        public async Task<IActionResult> DeleteRangeOperationClaimAsync([FromBody] DeleteRangeOperationClaimCommandRequest deleteRangeOperationClaimCommandRequest)
        {
            var response = await base._mediator.Send(deleteRangeOperationClaimCommandRequest);

            return response.Response.IsSucceeded == true
                ? Ok(response.Response)
                : BadRequest(response.Response.Title + ":" + response.Response.Message);
        }

        [HttpPut("UpdateOperationClaim")]
        public async Task<IActionResult> UpdateOperationClaimAsync([FromBody] UpdateOperationClaimCommandRequest updateOperationClaimCommandRequest)
        {
            var response = await base._mediator.Send(updateOperationClaimCommandRequest);

            return response.Response.IsSucceeded == true
                ? Ok(response.Response)
                : BadRequest(response.Response.Title + ":" + response.Response.Message);
        }
    }
}
