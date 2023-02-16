using ESISA.Core.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Domain.Entities
{
    public class IndividualCustomerIndividualDealerComment : EntityBase
    {
        public Guid IndividualCustomerId { get; set; }
        public Guid IndividualDealerId { get; set; }

        public String Title { get; set; }
        public String Content { get; set; }


        public virtual IndividualCustomer IndividualCustomer { get; set; }
        public virtual IndividualDealer IndividualDealer { get; set; }
    }
}
