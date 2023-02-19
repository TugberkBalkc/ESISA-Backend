using System.Security.Claims;

namespace ESISA.WebAPI.Extensions
{
    public static class HttpContextExtension
    {
        public static String GetUserId(this HttpContext httpContext) => httpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        public static String GetFirstName(this HttpContext httpContext) => httpContext.User.FindFirst(ClaimTypes.Name)?.Value;
        public static String GetLastName(this HttpContext httpContext) => httpContext.User.FindFirst(ClaimTypes.Surname)?.Value;
        public static String GetEmail(this HttpContext httpContext) => httpContext.User.FindFirst(ClaimTypes.Email)?.Value;
        public static String[] GetRoles(this HttpContext httpContext) => httpContext.User.FindAll(ClaimTypes.Role)?.Select(e=>e.Value).ToArray();
    }
}
