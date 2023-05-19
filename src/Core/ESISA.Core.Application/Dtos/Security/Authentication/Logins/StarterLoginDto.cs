using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Dtos.Security.Authentication.Logins
{
    public class StarterLoginDto
    {
        public String StarterEmail { get; set; }
        public String StarterPassword { get; set; }

        public StarterLoginDto()
        {

        }

        public StarterLoginDto(string starterEmail, string starterPassword)
        {
            StarterEmail = starterEmail;
            StarterPassword = starterPassword;
        }
    }
}
