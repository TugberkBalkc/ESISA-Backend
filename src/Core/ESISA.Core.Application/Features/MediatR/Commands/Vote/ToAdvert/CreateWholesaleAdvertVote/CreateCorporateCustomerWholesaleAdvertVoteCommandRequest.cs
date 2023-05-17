using BuildingBlocks.Events.Comment;
using ESISA.Core.Domain.Entities;
using ESISA.Core.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Features.MediatR.Commands.Votes.ToAdvert.CreateWholesaleAdvertVote
{
    public class CreateCorporateCustomerWholesaleAdvertVoteCommandRequest : IRequest<CreateCorporateCustomerWholesaleAdvertVoteCommandResponse>
    {
        public Guid CorporateCustomerId { get; set; }
        public Guid WholesaleAdvertId { get; set; }
        public VoteType VoteType { get; set; }

        public CreateCorporateCustomerWholesaleAdvertVoteCommandRequest()
        {

        }

        public CreateCorporateCustomerWholesaleAdvertVoteCommandRequest(Guid corporateCustomerId, Guid wholesaleAdvertId, VoteType voteType)
        {
            CorporateCustomerId = corporateCustomerId;
            WholesaleAdvertId = wholesaleAdvertId;
            VoteType = voteType;
        }
    }
}
