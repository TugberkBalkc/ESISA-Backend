using ESISA.Core.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Dtos.Security.Authentication.Registrations
{
    public class RegisterCorporateCustomerDto
    {
        public String CorporateCustomerEmail { get; set; }
        public String CorporateCustomerUserName { get; set; }
        public String CorporateCustomerContactNumber { get; set; }
        public String CorporateCustomerPassword { get; set; }

        public String CorporateCustomerCompanyName { get; set; }
        public String CorporateCustomerTaxIdentityNumber { get; set; }
        public CompanyType CorporateCustomerCompanyType { get; set; }
    }
}
