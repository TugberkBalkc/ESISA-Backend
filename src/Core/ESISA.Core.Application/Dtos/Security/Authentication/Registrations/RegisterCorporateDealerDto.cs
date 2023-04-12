using ESISA.Core.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Dtos.Security.Authentication.Registrations
{
    public class RegisterCorporateDealerDto
    {
        public String CorporateDealerEmail { get; set; }
        public String CorporateDealerUserName { get; set; }
        public String CorporateDealerContactNumber { get; set; }
        public String CorporateDealerPassword { get; set; }

        public String CorporateDealerCompanyName { get; set; }
        public String CorporateDealerTaxIdentityNumber { get; set; }
        public CompanyType CorporateDealerCompanyType { get; set; }
    }
}
