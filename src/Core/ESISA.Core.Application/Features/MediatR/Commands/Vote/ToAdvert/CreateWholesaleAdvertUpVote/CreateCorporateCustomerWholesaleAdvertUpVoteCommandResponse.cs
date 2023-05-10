using ESISA.Core.Application.Dtos.Evaluation.Votes;
using ESISA.Core.Application.Features.MediatR.Requests.Common;
using ESISA.Core.Application.Utilities.Response.Common;

namespace ESISA.Core.Application.Features.MediatR.Commands.Vote.ToAdvert.CreateWholesaleAdvertUpVote
{
    public class CreateCorporateCustomerWholesaleAdvertUpVoteCommandResponse : CommandResponseBase<CorporateCustomerWholesaleAdvertVoteDto>
    {
        public CreateCorporateCustomerWholesaleAdvertUpVoteCommandResponse(IContentResponse<CorporateCustomerWholesaleAdvertVoteDto> response) : base(response)
        {
        }
    }

}
