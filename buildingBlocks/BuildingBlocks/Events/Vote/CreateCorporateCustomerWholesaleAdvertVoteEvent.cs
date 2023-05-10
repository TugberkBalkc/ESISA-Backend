using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingBlocks.Events.Vote
{
    public class CreateCorporateCustomerWholesaleAdvertVoteEvent
    {
        public Guid CorporateCustomerId { get; set; }
        public Guid WholesaleAdvertId { get; set; }
        public int VoteType { get; set; }
    }
}
