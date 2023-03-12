using ESISA.Core.Application.Features.MediatR.Commands.Roles.AddOperationClaim;
using ESISA.Core.Application.Features.MediatR.Commands.Roles.Create;
using ESISA.Core.Application.Features.MediatR.Commands.Roles.Delete;
using ESISA.Core.Application.Features.MediatR.Commands.Roles.DeleteOperationClaim;
using ESISA.Core.Application.Features.MediatR.Commands.Roles.DeleteRange;
using ESISA.Core.Application.Features.MediatR.Commands.Roles.Update;
using ESISA.WebAPI.Controllers.Common;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ESISA.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : CustomControllerBase
    {
        public RolesController(IHttpContextAccessor httpContextAccessor, IMediator mediator) : base(httpContextAccessor, mediator)
        {
        }

        [HttpPost("AddOperationClaimToRole")]
        public async Task<IActionResult> AddOperationClaimToRoleAsync([FromBody] AddOperationClaimToRoleCommandRequest addOperationClaimToRoleCommandRequest)
        {
            var response = await _mediator.Send(addOperationClaimToRoleCommandRequest);

            return this.ActionResultInstanceByResponse(response.Response);
        }

        [HttpDelete("DeleteOperationClaimInRole")]
        public async Task<IActionResult> DeleteOperationClaimInRoleAsync([FromBody] DeleteOperationClaimInRoleCommandRequest deleteOperationClaimInRoleCommandRequest)
        {
            var response = await _mediator.Send(deleteOperationClaimInRoleCommandRequest);

            return this.ActionResultInstanceByResponse(response.Response);
        }

        [HttpPost("CreateRole")]
        public async Task<IActionResult> CreateRoleAsync([FromBody] CreateRoleCommandRequest createRoleCommandRequest)
        {
            var response = await _mediator.Send(createRoleCommandRequest);

            return this.ActionResultInstanceByResponse(response.Response);
        }

        [HttpDelete("DeleteRole")]
        public async Task<IActionResult> DeleteRoleAsync([FromBody] DeleteRoleCommandRequest deleteRoleCommandRequest)
        {
            var response = await _mediator.Send(deleteRoleCommandRequest);

            return this.ActionResultInstanceByResponse(response.Response);
        }

        [HttpDelete("DeleteRangeRole")]
        public async Task<IActionResult> DeleteRangeRoleAsync([FromBody] DeleteRangeRoleCommandRequest deleteRangeRoleCommandRequest)
        {
            var response = await _mediator.Send(deleteRangeRoleCommandRequest);

            return this.ActionResultInstanceByResponse(response.Response);
        }

        [HttpPut("UpdateRole")]
        public async Task<IActionResult> UpdateRoleAsync([FromBody] UpdateRoleCommandRequest updateRoleCommandRequest)
        {
            var response = await _mediator.Send(updateRoleCommandRequest);

            return this.ActionResultInstanceByResponse(response.Response);
        }
    }
}
