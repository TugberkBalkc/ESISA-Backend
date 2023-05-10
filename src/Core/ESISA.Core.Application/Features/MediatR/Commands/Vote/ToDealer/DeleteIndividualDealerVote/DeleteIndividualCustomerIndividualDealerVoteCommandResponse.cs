using ESISA.Core.Application.Features.MediatR.Requests.Common;
using ESISA.Core.Application.Utilities.Response.Common;

namespace ESISA.Core.Application.Features.MediatR.Commands.Vote.ToDealer.DeleteIndividualDealerVote
{
    public class DeleteIndividualCustomerIndividualDealerVoteCommandResponse : CommandResponseBase<Guid>
    {
        public DeleteIndividualCustomerIndividualDealerVoteCommandResponse(IContentResponse<Guid> response) : base(response)
        {
        }
    }
}
