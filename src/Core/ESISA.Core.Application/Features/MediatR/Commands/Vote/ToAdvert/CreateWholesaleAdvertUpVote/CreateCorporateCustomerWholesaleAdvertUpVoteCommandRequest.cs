using MediatR;

namespace ESISA.Core.Application.Features.MediatR.Commands.Vote.ToAdvert.CreateWholesaleAdvertUpVote
{
    public class CreateCorporateCustomerWholesaleAdvertUpVoteCommandRequest : IRequest<CreateCorporateCustomerWholesaleAdvertUpVoteCommandResponse>
    {
        public Guid CorporateCustomerId { get; set; }
        public Guid WholesaleAdvertId { get; set; }

        public CreateCorporateCustomerWholesaleAdvertUpVoteCommandRequest()
        {

        }

        public CreateCorporateCustomerWholesaleAdvertUpVoteCommandRequest(Guid corporateCustomerId, Guid wholesaleAdvertId)
        {
            CorporateCustomerId = corporateCustomerId;
            WholesaleAdvertId = wholesaleAdvertId;
        }
    }

}
