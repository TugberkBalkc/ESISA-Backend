using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Dtos.Security.Authentication.Logins
{
    public class CorporateCustomerLoginDto
    {
        public String CorporateCustomerTaxIdentityNumber { get; set; }
        public String CorporateCustomerPassword { get; set; }
    }
}
