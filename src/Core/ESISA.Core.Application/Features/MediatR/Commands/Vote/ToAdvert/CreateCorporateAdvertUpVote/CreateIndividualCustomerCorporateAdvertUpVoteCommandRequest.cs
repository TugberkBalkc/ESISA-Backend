using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Features.MediatR.Commands.Vote.ToAdvert.CreateCorporateAdvertUpVote
{

    public class CreateIndividualCustomerCorporateAdvertUpVoteCommandRequest : IRequest<CreateIndividualCustomerCorporateAdvertUpVoteCommandResponse>
    {
        public Guid IndividualCustomerId { get; set; }
        public Guid CorporateAdvertId { get; set; }

        public CreateIndividualCustomerCorporateAdvertUpVoteCommandRequest()
        {

        }

        public CreateIndividualCustomerCorporateAdvertUpVoteCommandRequest(Guid ındividualCustomerId, Guid corporateAdvertId)
        {
            IndividualCustomerId = ındividualCustomerId;
            CorporateAdvertId = corporateAdvertId;
        }
    }
}
