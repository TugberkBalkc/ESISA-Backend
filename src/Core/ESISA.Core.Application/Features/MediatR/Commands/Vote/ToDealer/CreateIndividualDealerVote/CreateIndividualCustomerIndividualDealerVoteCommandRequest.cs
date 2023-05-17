using ESISA.Core.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Features.MediatR.Commands.Votes.ToDealer.CreateIndividualDealerVote
{
    public class CreateIndividualCustomerIndividualDealerVoteCommandRequest : IRequest<CreateIndividualCustomerIndividualDealerVoteCommandResponse>
    {
        public Guid IndividualCustomerId { get; set; }
        public Guid IndividualDealerId { get; set; }
        public VoteType VoteType { get; set; }

        public CreateIndividualCustomerIndividualDealerVoteCommandRequest()
        {

        }

        public CreateIndividualCustomerIndividualDealerVoteCommandRequest(Guid ındividualCustomerId, Guid ındividualDealerId, VoteType voteType)
        {
            IndividualCustomerId = ındividualCustomerId;
            IndividualDealerId = ındividualDealerId;
            VoteType = voteType;
        }
    }
}
