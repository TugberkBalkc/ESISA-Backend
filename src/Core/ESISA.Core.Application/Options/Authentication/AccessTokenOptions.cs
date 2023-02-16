using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Options.Authentication
{
    public class AccessTokenOptions
    {
        public String Audience { get; set; }
        public String Issuer { get; set; }
        public String SecretKey { get; set; }
        public int TokenLifeTimeInMinutes { get; set; }
    }
}
