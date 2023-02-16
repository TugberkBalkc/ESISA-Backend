using ESISA.Core.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Domain.Entities
{
    public class IndividualCustomerAddress : EntityBase
    {
        public Guid IndividualCustomerId { get; set; }
        public Guid AddressId { get; set; }

        public bool IsResidence { get; set; }


        public virtual IndividualCustomer IndividualCustomer { get; set; }
        public virtual Address Address { get; set; }

        public virtual ICollection<IndividualCustomerCorporateAdvertOrder> IndividualCustomerCorporateAdvertOrders { get; set; }

    }
}
