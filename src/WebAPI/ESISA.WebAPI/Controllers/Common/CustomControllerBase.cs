using ESISA.WebAPI.Extensions;
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

        protected Guid UserId => Guid.Parse(_httpContextAccessor.HttpContext.GetUserId());
        protected String FirstName => _httpContextAccessor.HttpContext.GetFirstName();
        protected String LastName => _httpContextAccessor.HttpContext.GetLastName();
        protected String Email => _httpContextAccessor.HttpContext.GetEmail();
        protected String[] Roles => _httpContextAccessor.HttpContext.GetRoles();
    }
}
