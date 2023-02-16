using ESISA.Core.Domain.Entities.Common;
using ESISA.Core.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Domain.Entities 
{ 
    public class CorporateCustomerWholesaleAdvertVote : EntityBase
    {
        public Guid CorporateCustomerId { get; set; }
        public Guid WholesaleAdvertId { get; set; }

        public VoteType VoteType { get; set; }


        public virtual CorporateCustomer CorporateCustomer { get; set; }
        public virtual WholesaleAdvert WholesaleAdvert { get; set; }
    }
}
