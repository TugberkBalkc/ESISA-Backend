using ESISA.Core.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Dtos.User
{
    public class CorporateDealerDto
    {
        public Guid CorporateDealerId { get; set; }
        public DateTime CorporateDealerCreatedDate { get; set; }
        public DateTime CorporateDealerModifiedDate { get; set; }
        public bool CorporateDealerIsDeleted { get; set; }
        public bool CorporateDealerIsActive { get; set; }

        public String CorporateDealerEmail { get; set; }
        public String CorporateDealerUserName { get; set; }
        public String CorporateDealerContactNumber { get; set; }
        public String CorporateDealerPassword { get; set; }

        public Guid CorporateDealerSalesCategoryId { get; set; }
        public Guid CorporateDealerAddressId { get; set; }
        public String CorporateDealerCompanyName { get; set; }
        public String CorporateDealerTaxIdentityNumber { get; set; }
        public CompanyType CorporateDealerCompanyType { get; set; }

        public bool CorporateDealerStatus { get; set; }
    }
}
