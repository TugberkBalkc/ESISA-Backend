using ESISA.Core.Application.Features.MediatR.Requests.Common;
using ESISA.Core.Application.Utilities.Response.Common;

namespace ESISA.Core.Application.Features.MediatR.Commands.Votes.ToAdvert.DeleteWholesaleAdvertVote
{
    public class DeleteCorporateCustomerWholesaleAdvertVoteCommandResponse : CommandResponseBase<Guid>
    {
        public DeleteCorporateCustomerWholesaleAdvertVoteCommandResponse(IContentResponse<Guid> response) : base(response)
        {
        }
    }
}


