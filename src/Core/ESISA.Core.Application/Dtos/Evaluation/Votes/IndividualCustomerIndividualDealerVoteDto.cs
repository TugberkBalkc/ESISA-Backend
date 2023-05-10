using ESISA.Core.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Dtos.Evaluation.Votes
{
    public class IndividualCustomerIndividualDealerVoteDto
    {
        public Guid IndividualCustomerId { get; set; }
        public Guid IndividualDealerId { get; set; }
        public VoteType VoteType { get; set; }

        public IndividualCustomerIndividualDealerVoteDto()
        {

        }

        public IndividualCustomerIndividualDealerVoteDto(Guid ındividualCustomerId, Guid ındividualDealerId, VoteType voteType)
        {
            IndividualCustomerId = ındividualCustomerId;
            IndividualDealerId = ındividualDealerId;
            VoteType = voteType;
        }
    }
}
