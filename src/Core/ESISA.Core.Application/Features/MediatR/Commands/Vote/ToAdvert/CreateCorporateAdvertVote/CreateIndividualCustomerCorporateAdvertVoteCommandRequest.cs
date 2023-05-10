using ESISA.Core.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Features.MediatR.Commands.Vote.ToAdvert.CreateCorporateAdvertVote
{
    public class CreateIndividualCustomerCorporateAdvertVoteCommandRequest : IRequest<CreateIndividualCustomerCorporateAdvertVoteCommandResponse>
    {
        public Guid IndividualCustomerId { get; set; }
        public Guid CorporateAdvertId { get; set; }
        public VoteType VoteType { get; set; }

        public CreateIndividualCustomerCorporateAdvertVoteCommandRequest()
        {

        }

        public CreateIndividualCustomerCorporateAdvertVoteCommandRequest(Guid ındividualCustomerId, Guid corporateAdvertId, VoteType voteType)
        {
            IndividualCustomerId = ındividualCustomerId;
            CorporateAdvertId = corporateAdvertId;
            VoteType = voteType;
        }
    }
}
