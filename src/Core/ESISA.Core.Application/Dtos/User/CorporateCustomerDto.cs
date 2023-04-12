using ESISA.Core.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Dtos.CorporateCustomer
{
    public class CorporateCustomerDto
    {
        public Guid CorporateCustomerUserId { get; set; }
        public Guid CorporateCustomerCustomerId { get; set; }
        public Guid CorporateCustomerId { get; set; }

        public DateTime CorporateCustomerUserCreatedDate { get; set; }
        public DateTime CorporateCustomerUserModifiedDate { get; set; }
        public bool CorporateCustomerUserIsDeleted { get; set; }
        public bool CorporateCustomerUserIsActive { get; set; }

        public String CorporateCustomerEmail { get; set; }
        public String CorporateCustomerUserName { get; set; }
        public String CorporateCustomerContactNumber { get; set; }
        public String CorporateCustomerPassword { get; set; }

        public String CorporateCustomerCompanyName { get; set; }
        public String CorporateCustomerTaxIdentityNumber { get; set; }
        public CompanyType CorporateCustomerCompanyType { get; set; }

        public bool CorporateCustomerStatus { get; set; }
    }
}
