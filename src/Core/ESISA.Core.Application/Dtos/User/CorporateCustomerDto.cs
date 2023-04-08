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
        public Guid CorporateCustomerId { get; set; }
        public DateTime CorporateCustomerCreatedDate { get; set; }
        public DateTime CorporateCustomerModifiedDate { get; set; }
        public bool CorporateCustomerIsDeleted { get; set; }
        public bool CorporateCustomerIsActive { get; set; }

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
