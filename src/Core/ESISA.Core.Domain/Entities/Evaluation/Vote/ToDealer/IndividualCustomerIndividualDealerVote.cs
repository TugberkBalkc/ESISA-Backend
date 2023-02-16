using ESISA.Core.Domain.Entities.Common;
using ESISA.Core.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Domain.Entities
{
    public class IndividualCustomerIndividualDealerVote : EntityBase
    {
        public Guid IndividualCustomerId { get; set; }
        public Guid IndividualDealerId { get; set; }

        public VoteType VoteType { get; set; }


        public virtual IndividualCustomer IndividualCustomer { get; set; }
        public virtual IndividualDealer IndividualDealer { get; set; }
    }
}
