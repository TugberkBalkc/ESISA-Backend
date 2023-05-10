using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Features.MediatR.Commands.Vote.ToDealer.DeleteIndividualDealerVote
{

    public class DeleteIndividualCustomerIndividualDealerVoteCommandRequest : IRequest<DeleteIndividualCustomerIndividualDealerVoteCommandResponse>
    {
        public Guid IndividualCustomerId { get; set; }
        public Guid IndividualDealerId { get; set; }

        public DeleteIndividualCustomerIndividualDealerVoteCommandRequest()
        {

        }

        public DeleteIndividualCustomerIndividualDealerVoteCommandRequest(Guid ındividualCustomerId, Guid ındividualDealerId)
        {
            IndividualCustomerId = ındividualCustomerId;
            IndividualDealerId = ındividualDealerId;
        }
    }
}
