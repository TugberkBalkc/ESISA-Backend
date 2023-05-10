using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingBlocks.Events.Vote
{
    public class CreateIndividualCustomerCorporateAdvertVoteEvent
    {
        public Guid IndividualCustomerId { get; set; }
        public Guid CorporateAdvertId { get; set; }
        public int VoteType { get; set; }
    }
}
