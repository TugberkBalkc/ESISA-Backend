using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingBlocks.Events.Vote
{
    public class CreateIndividualCustomerIndividualDealerVoteEvent
    {
        public Guid IndividualCustomerId { get; set; }
        public Guid IndividualDealerId { get; set; }
        public int VoteType { get; set; }
    }
}
