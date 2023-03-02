using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Options.Authentication
{
    public class TokenOptions
    {
        public String Audience { get; set; }
        public String Issuer { get; set; }
        public String SecretKey { get; set; }
        public int AccessTokenLifeTimeInMinutes { get; set; }
        public int RefreshTokenLifeTimeInMinutes { get; set; }
    }
}
