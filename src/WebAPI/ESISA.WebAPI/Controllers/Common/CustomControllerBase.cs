using ESISA.Core.Application.Extensions.ClaimExtensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ESISA.WebAPI.Controllers.Common
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomControllerBase : ControllerBase
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CustomControllerBase(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        protected Guid UserId => Guid.Parse(_httpContextAccessor.HttpContext.GetUsersId());
        protected String FirstName => _httpContextAccessor.HttpContext.GetUsersFirstName();
        protected String LastName => _httpContextAccessor.HttpContext.GetUsersLastName();
        protected String Email => _httpContextAccessor.HttpContext.GetUsersEmail();
        protected String[] Roles => _httpContextAccessor.HttpContext.GetUsersRoles();
    }
}
