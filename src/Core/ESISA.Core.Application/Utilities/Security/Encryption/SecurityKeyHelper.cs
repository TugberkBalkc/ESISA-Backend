using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Utilities.Security.Encryption
{
    public class SecurityKeyHelper
    {
        public static SymmetricSecurityKey CreateSymmetricSecurityKey(string secretKey)
        {
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
        }
    }
}
