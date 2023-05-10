using ESISA.Core.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Dtos.Evaluation.Votes
{
    public class IndividualCustomerCorporateAdvertVoteDto
    {
        public Guid IndividualCustomerId { get; set; }
        public Guid CorporateAdvertId { get; set; }
        public VoteType VoteType { get; set; }

        public IndividualCustomerCorporateAdvertVoteDto()
        {

        }

        public IndividualCustomerCorporateAdvertVoteDto(Guid ındividualCustomerId, Guid corporateAdvertId, VoteType voteType)
        {
            IndividualCustomerId = ındividualCustomerId;
            CorporateAdvertId = corporateAdvertId;
            VoteType = voteType;
        }
    }
}
