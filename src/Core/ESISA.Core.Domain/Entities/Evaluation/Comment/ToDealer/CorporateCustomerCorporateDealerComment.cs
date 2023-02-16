using ESISA.Core.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Domain.Entities
{
    public class CorporateCustomerCorporateDealerComment : EntityBase
    {
        public Guid CorporateCustomerId { get; set; }
        public Guid CorporateDealerId { get; set; }

        public String Title { get; set; }
        public String Content { get; set; }


        public virtual CorporateCustomer CorporateCustomer { get; set; }
        public virtual CorporateDealer CorporateDealer { get; set; }
    }
}
