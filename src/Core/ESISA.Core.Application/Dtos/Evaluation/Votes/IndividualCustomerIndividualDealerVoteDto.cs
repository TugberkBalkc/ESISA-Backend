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
        public Guid IndividualCustomerIndividualDealerVoteId { get; set; }
        public DateTime IndividualCustomerIndividualDealerVoteCreatedDate { get; set; }
        public DateTime IndividualCustomerIndividualDealerVoteModifiedDate { get; set; }
        public bool IndividualCustomerIndividualDealerVoteIsActive { get; set; }
        public bool IndividualCustomerIndividualDealerVoteIsDeleted { get; set; }

        public Guid IndividualCustomerId { get; set; }
        public Guid IndividualDealerId { get; set; }
        public VoteType VoteType { get; set; }

        public IndividualCustomerIndividualDealerVoteDto()
        {

        }

        public IndividualCustomerIndividualDealerVoteDto(Guid ındividualCustomerIndividualDealerVoteId, DateTime ındividualCustomerIndividualDealerVoteCreatedDate, DateTime ındividualCustomerIndividualDealerVoteModifiedDate, bool ındividualCustomerIndividualDealerVoteIsActive, bool ındividualCustomerIndividualDealerVoteIsDeleted, Guid ındividualCustomerId, Guid ındividualDealerId, VoteType voteType)
        {
            IndividualCustomerIndividualDealerVoteId = ındividualCustomerIndividualDealerVoteId;
            IndividualCustomerIndividualDealerVoteCreatedDate = ındividualCustomerIndividualDealerVoteCreatedDate;
            IndividualCustomerIndividualDealerVoteModifiedDate = ındividualCustomerIndividualDealerVoteModifiedDate;
            IndividualCustomerIndividualDealerVoteIsActive = ındividualCustomerIndividualDealerVoteIsActive;
            IndividualCustomerIndividualDealerVoteIsDeleted = ındividualCustomerIndividualDealerVoteIsDeleted;
            IndividualCustomerId = ındividualCustomerId;
            IndividualDealerId = ındividualDealerId;
            VoteType = voteType;
        }
    }
}
