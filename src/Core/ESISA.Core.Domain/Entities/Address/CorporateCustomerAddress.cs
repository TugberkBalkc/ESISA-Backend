using ESISA.Core.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Domain.Entities
{
    public class CorporateCustomerAddress : EntityBase
    {
        public Guid CorporateCustomerId { get; set; }
        public Guid AddressId { get; set; }

        public bool IsCenterCompany { get; set; }


        public virtual CorporateCustomer CorporateCustomer { get; set; }
        public virtual Address Address { get; set; }

        public virtual ICollection<CorporateCustomerWholesaleAdvertOrder> CorporateCustomerWholesaleAdvertOrders { get; set; }
    }
}
