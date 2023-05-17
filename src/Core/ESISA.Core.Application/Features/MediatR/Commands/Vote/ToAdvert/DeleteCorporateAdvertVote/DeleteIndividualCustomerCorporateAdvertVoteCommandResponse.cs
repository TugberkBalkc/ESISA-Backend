using ESISA.Core.Application.Features.MediatR.Requests.Common;
using ESISA.Core.Application.Utilities.Response.Common;

namespace ESISA.Core.Application.Features.MediatR.Commands.Votes.ToAdvert.DeleteCorporateAdvertVote
{
    public class DeleteIndividualCustomerCorporateAdvertVoteCommandResponse : CommandResponseBase<Guid>
    {
        public DeleteIndividualCustomerCorporateAdvertVoteCommandResponse(IContentResponse<Guid> response) : base(response)
        {
        }
    }

}
