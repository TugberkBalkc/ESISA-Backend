using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Infrastructure.Extensions.Claims
{
    public static class ClaimExtensions
    {
        public static void AddId(this ICollection<Claim> claims, Guid id)
        {
            claims.Add(new Claim(ClaimTypes.NameIdentifier, id.ToString()));
        }
        public static void AddFirstName(this ICollection<Claim> claims, String firstName)
        {
            claims.Add(new Claim(ClaimTypes.Name, firstName));
        }

        public static void AddLastName(this ICollection<Claim> claims, String lastName)
        {
            claims.Add(new Claim(ClaimTypes.Surname, lastName));
        }

        public static void AddEmail(this ICollection<Claim> claims, String email)
        {
            claims.Add(new Claim(ClaimTypes.Email, email));
        }

        public static void AddRole(this ICollection<Claim> claims, String roleName)
        {
            claims.Add(new Claim(ClaimTypes.Role, roleName));
        }

        public static void AddRoles(this ICollection<Claim> claims, String[] roleNames)
        {
            roleNames.ToList().ForEach(r =>
            {
                claims.Add(new Claim(ClaimTypes.Role, r));
            });
        }

        public static void AddOperationClaims(this ICollection<Claim> claims, String[] operationClaims)
        {
            operationClaims
                .ToList()
                .ForEach(opc =>
                {
                    claims.Add(new Claim(ClaimTypes.Role, opc));
                });
        }
    }
}
