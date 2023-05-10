using ESISA.Core.Application.Features.MediatR.Commands.Vote.ToAdvert.CreateWholesaleAdvertVote;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Features.MediatR.Commands.Vote.ToAdvert.CreateWholesaleAdvertDownVote
{
    public class CreateCorporateCustomerWholesaleAdveretDownVoteCommandRequest : IRequest<CreateCorporateCustomerWholesaleAdveretDownVoteCommandResponse>
    {
        public Guid CorporateCustomerId { get; set; }
        public Guid WholesaleAdvertId { get; set; }

        public CreateCorporateCustomerWholesaleAdveretDownVoteCommandRequest()
        {

        }

        public CreateCorporateCustomerWholesaleAdveretDownVoteCommandRequest(Guid corporateCustomerId, Guid wholesaleAdvertId)
        {
            CorporateCustomerId = corporateCustomerId;
            WholesaleAdvertId = wholesaleAdvertId;
        }
    }
}
