using ESISA.Core.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Domain.Entities
{
    public class IndividualDealer : EntityBase
    {
        public Guid DealerId { get; set; }

        public virtual Dealer Dealer { get; set; }

        public virtual ICollection<IndividualAdvert> IndividualAdverts { get; set; }
        public virtual ICollection<SwapAdvert> SwapAdverts { get; set; }

        public virtual ICollection<IndividualCustomerIndividualDealerComment> IndividualCustomerIndividualDealerComments { get; set; }
        public virtual ICollection<IndividualCustomerIndividualDealerVote> IndividualCustomerIndividualDealerVotes { get; set; }
    }
}
