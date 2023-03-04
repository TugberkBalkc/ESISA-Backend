using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace ESISA.Core.Application.Extensions.ClaimExtensions
{
    public static class HttpContextExtension
    {
        public static String GetUsersId(this HttpContext httpContext) => httpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        public static String GetUsersFirstName(this HttpContext httpContext) => httpContext.User.FindFirst(ClaimTypes.Name)?.Value;
        public static String GetUsersLastName(this HttpContext httpContext) => httpContext.User.FindFirst(ClaimTypes.Surname)?.Value;
        public static String GetUsersEmail(this HttpContext httpContext) => httpContext.User.FindFirst(ClaimTypes.Email)?.Value;
        public static String[] GetUsersRoles(this HttpContext httpContext) => httpContext.User.FindAll(ClaimTypes.Role)?.Select(e=>e.Value).ToArray();
    }
}
