using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Features.MediatR.Commands.Vote.ToAdvert.DeleteCorporateAdvertVote
{
    public class DeleteIndividualCustomerCorporateAdvertVoteCommandRequest : IRequest<DeleteIndividualCustomerCorporateAdvertVoteCommandResponse>
    {
        public Guid IndividualCustomerId { get; set; }
        public Guid CorporateAdvertId { get; set; }

        public DeleteIndividualCustomerCorporateAdvertVoteCommandRequest()
        {

        }

        public DeleteIndividualCustomerCorporateAdvertVoteCommandRequest(Guid ındividualCustomerId, Guid corporateAdvertId)
        {
            IndividualCustomerId = ındividualCustomerId;
            CorporateAdvertId = corporateAdvertId;
        }
    }

}
