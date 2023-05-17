using ESISA.Core.Application.Features.MediatR.Commands.Votes.ToDealer.CreateIndividualDealerVote;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Features.MediatR.Commands.Votes.ToDealer.CreateIndividualDealerUpVote
{
    public class CreateIndividualCustomerIndividualDealerUpVoteCommandRequest : IRequest<CreateIndividualCustomerIndividualDealerUpVoteCommandResponse>
    {
        public Guid IndividualCustomerId { get; set; }
        public Guid IndividualDealerId { get; set; }
        
        public CreateIndividualCustomerIndividualDealerUpVoteCommandRequest()
        {

        }

        public CreateIndividualCustomerIndividualDealerUpVoteCommandRequest(Guid ındividualCustomerId, Guid ındividualDealerId)
        {
            IndividualCustomerId = ındividualCustomerId;
            IndividualDealerId = ındividualDealerId;
        }
    }
}
