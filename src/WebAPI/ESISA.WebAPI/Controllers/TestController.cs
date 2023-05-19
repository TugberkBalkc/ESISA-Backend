using ESISA.Core.Application.Features.MediatR.Commands.UserRoles;
using ESISA.Core.Application.Features.MediatR.Commands.UserRoles.Create;
using ESISA.Core.Application.Interfaces.Repositories;
using ESISA.WebAPI.Controllers.Common;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ESISA.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : CustomControllerBase
    {
        private readonly IUserQueryRepository _userQueryRepository;

        public TestController(IHttpContextAccessor httpContextAccessor, IMediator mediator, IUserQueryRepository userQueryRepository) : base(httpContextAccessor, mediator)
        {
            _userQueryRepository = userQueryRepository;
        }

        [HttpGet("GetUserRolesByUserId")]
        public async Task<IActionResult> GetUserRolesByUserIdAsync(Guid userId)
        {
           var roles = _userQueryRepository.GetRolesByUserId(userId);

            return Ok(roles.ToList());
        }

        [HttpPost("CreateUserRole")]
        public async Task<IActionResult> CreateUserRole(CreateUserRoleCommandRequest createUserRoleCommandRequest)
        {
            var response = await _mediator.Send(createUserRoleCommandRequest);

            return Ok(response.Response);
        }
    }
}
