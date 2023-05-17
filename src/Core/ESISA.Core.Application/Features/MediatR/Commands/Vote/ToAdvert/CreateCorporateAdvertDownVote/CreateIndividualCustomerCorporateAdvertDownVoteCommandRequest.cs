using ESISA.Core.Application.Features.MediatR.Commands.Votes.ToAdvert.CreateCorporateAdvertVote;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Features.MediatR.Commands.Votes.ToAdvert.CreateCorporateAdvertDownVote
{
    public class CreateIndividualCustomerCorporateAdvertDownVoteCommandRequest : IRequest<CreateIndividualCustomerCorporateAdvertDownVoteCommandResponse>
    {
        public Guid IndividualCustomerId { get; set; }
        public Guid CorporateAdvertId { get; set; }

        public CreateIndividualCustomerCorporateAdvertDownVoteCommandRequest()
        {

        }

        public CreateIndividualCustomerCorporateAdvertDownVoteCommandRequest(Guid ındividualCustomerId, Guid corporateAdvertId)
        {
            IndividualCustomerId = ındividualCustomerId;
            CorporateAdvertId = corporateAdvertId;
        }
    }
}
