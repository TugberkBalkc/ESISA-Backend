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
        public Guid CorporateCustomerWholesaleAdvertVoteId { get; set; }
        public DateTime CorporateCustomerWholesaleAdvertVoteCreatedDate { get; set; }
        public DateTime CorporateCustomerWholesaleAdvertVoteModifiedDate { get; set; }
        public bool CorporateCustomerWholesaleAdvertVoteIsActive { get; set; }
        public bool CorporateCustomerWholesaleAdvertVoteIsDeleted { get; set; }

        public Guid CorporateCustomerId { get; set; }
        public Guid WholesaleAdvertId { get; set; }
        public VoteType VoteType { get; set; }

        public CorporateCustomerWholesaleAdvertVoteDto()
        {

        }

        public CorporateCustomerWholesaleAdvertVoteDto(Guid corporateCustomerWholesaleAdvertVoteId, DateTime corporateCustomerWholesaleAdvertVoteCreatedDate, DateTime corporateCustomerWholesaleAdvertVoteModifiedDate, bool corporateCustomerWholesaleAdvertVoteIsActive, bool corporateCustomerWholesaleAdvertVoteIsDeleted, Guid corporateCustomerId, Guid wholesaleAdvertId, VoteType voteType)
        {
            CorporateCustomerWholesaleAdvertVoteId = corporateCustomerWholesaleAdvertVoteId;
            CorporateCustomerWholesaleAdvertVoteCreatedDate = corporateCustomerWholesaleAdvertVoteCreatedDate;
            CorporateCustomerWholesaleAdvertVoteModifiedDate = corporateCustomerWholesaleAdvertVoteModifiedDate;
            CorporateCustomerWholesaleAdvertVoteIsActive = corporateCustomerWholesaleAdvertVoteIsActive;
            CorporateCustomerWholesaleAdvertVoteIsDeleted = corporateCustomerWholesaleAdvertVoteIsDeleted;
            CorporateCustomerId = corporateCustomerId;
            WholesaleAdvertId = wholesaleAdvertId;
            VoteType = voteType;
        }
    }
}
