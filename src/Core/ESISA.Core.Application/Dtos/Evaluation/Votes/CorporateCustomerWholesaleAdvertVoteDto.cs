using ESISA.Core.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Dtos.Evaluation.Votes
{
    public class CorporateCustomerWholesaleAdvertVoteDto
    {
        public Guid CorporateCustomerId { get; set; }
        public Guid WholesaleAdvertId { get; set; }
        public VoteType VoteType { get; set; }

        public CorporateCustomerWholesaleAdvertVoteDto()
        {

        }

        public CorporateCustomerWholesaleAdvertVoteDto(Guid corporateCustomerId, Guid wholesaleAdvertId, VoteType voteType)
        {
            CorporateCustomerId = corporateCustomerId;
            WholesaleAdvertId = wholesaleAdvertId;
            VoteType = voteType;
        }
    }
}
