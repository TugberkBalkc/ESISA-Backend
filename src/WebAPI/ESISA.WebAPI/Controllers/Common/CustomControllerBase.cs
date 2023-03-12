using ESISA.Core.Application.Extensions.ClaimExtensions;
using ESISA.Core.Application.Utilities.Response.Common;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ESISA.WebAPI.Controllers.Common
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomControllerBase : ControllerBase
    {
        protected readonly IHttpContextAccessor _httpContextAccessor;
        protected readonly IMediator _mediator;

        public CustomControllerBase(IHttpContextAccessor httpContextAccessor, IMediator mediator)
        {
            _httpContextAccessor = httpContextAccessor;
            _mediator = mediator;
        }

        protected Guid UserId => Guid.Parse(_httpContextAccessor.HttpContext.GetUsersId());
        protected String FirstName => _httpContextAccessor.HttpContext.GetUsersFirstName();
        protected String LastName => _httpContextAccessor.HttpContext.GetUsersLastName();
        protected String Email => _httpContextAccessor.HttpContext.GetUsersEmail();
        protected String[] Roles => _httpContextAccessor.HttpContext.GetUsersRoles();

        protected IActionResult ActionResultInstanceByResponse(IResponse response) 
        {
            return new ObjectResult(response)
            {
                StatusCode = Convert.ToInt16(response.StatusCode)
            };
        }
    }
}
