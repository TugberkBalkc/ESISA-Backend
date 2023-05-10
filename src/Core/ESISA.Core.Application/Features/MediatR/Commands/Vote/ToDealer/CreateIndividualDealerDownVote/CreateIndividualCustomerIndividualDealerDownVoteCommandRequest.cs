using ESISA.Core.Application.Features.MediatR.Commands.Vote.ToDealer.CreateIndividualDealerVote;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Features.MediatR.Commands.Vote.ToDealer.CreateIndividualDealerDownVote
{
    public class CreateIndividualCustomerIndividualDealerDownVoteCommandRequest : IRequest<CreateIndividualCustomerIndividualDealerDownVoteCommandResponse>
    {
        public Guid IndividualCustomerId { get; set; }
        public Guid IndividualDealerId { get; set; }

        public CreateIndividualCustomerIndividualDealerDownVoteCommandRequest()
        {

        }

        public CreateIndividualCustomerIndividualDealerDownVoteCommandRequest(Guid ındividualCustomerId, Guid ındividualDealerId)
        {
            IndividualCustomerId = ındividualCustomerId;
            IndividualDealerId = ındividualDealerId;
        }
    }
}
