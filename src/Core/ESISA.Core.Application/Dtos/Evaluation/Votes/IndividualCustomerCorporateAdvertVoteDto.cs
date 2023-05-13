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
        public Guid IndividualCustomerCorporateAdvertVoteId { get; set; }
        public DateTime IndividualCustomerCorporateAdvertVoteCreatedDate { get; set; }
        public DateTime IndividualCustomerCorporateAdvertVoteModifiedDate { get; set; }
        public bool IndividualCustomerCorporateAdvertVoteIsActive { get; set; }
        public bool IndividualCustomerCorporateAdvertVoteIsDeleted { get; set; }

        public Guid IndividualCustomerId { get; set; }
        public Guid CorporateAdvertId { get; set; }
        public VoteType VoteType { get; set; }

        public IndividualCustomerCorporateAdvertVoteDto()
        {

        }

        public IndividualCustomerCorporateAdvertVoteDto(Guid ındividualCustomerCorporateAdvertVoteId, DateTime ındividualCustomerCorporateAdvertVoteCreatedDate, DateTime ındividualCustomerCorporateAdvertVoteModifiedDate, bool ındividualCustomerCorporateAdvertVoteIsActive, bool ındividualCustomerCorporateAdvertVoteIsDeleted, Guid ındividualCustomerId, Guid corporateAdvertId, VoteType voteType)
        {
            IndividualCustomerCorporateAdvertVoteId = ındividualCustomerCorporateAdvertVoteId;
            IndividualCustomerCorporateAdvertVoteCreatedDate = ındividualCustomerCorporateAdvertVoteCreatedDate;
            IndividualCustomerCorporateAdvertVoteModifiedDate = ındividualCustomerCorporateAdvertVoteModifiedDate;
            IndividualCustomerCorporateAdvertVoteIsActive = ındividualCustomerCorporateAdvertVoteIsActive;
            IndividualCustomerCorporateAdvertVoteIsDeleted = ındividualCustomerCorporateAdvertVoteIsDeleted;
            IndividualCustomerId = ındividualCustomerId;
            CorporateAdvertId = corporateAdvertId;
            VoteType = voteType;
        }
    }
}
