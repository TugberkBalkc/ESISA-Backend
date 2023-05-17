using ESISA.Core.Application.Features.MediatR.Commands.Votes.ToAdvert.DeleteCorporateAdvertVote;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Features.MediatR.Commands.Votes.ToAdvert.DeleteWholesaleAdvertVote
{
    public class DeleteCorporateCustomerWholesaleAdvertVoteCommandRequest : IRequest<DeleteCorporateCustomerWholesaleAdvertVoteCommandResponse>
    {
        public Guid CorporateCustomerId { get; set; }
        public Guid WholesaleAdvertId { get; set; }

        public DeleteCorporateCustomerWholesaleAdvertVoteCommandRequest()
        {

        }

        public DeleteCorporateCustomerWholesaleAdvertVoteCommandRequest(Guid corporateCustomerId, Guid wholesaleAdvertId)
        {
            CorporateCustomerId = corporateCustomerId;
            WholesaleAdvertId = wholesaleAdvertId;
        }
    }
}


