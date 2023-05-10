using ESISA.Core.Application.Dtos.Evaluation.Votes;
using ESISA.Core.Application.Features.MediatR.Requests.Common;
using ESISA.Core.Application.Utilities.Response.Common;

namespace ESISA.Core.Application.Features.MediatR.Commands.Vote.ToAdvert.CreateWholesaleAdvertDownVote
{
    public class CreateCorporateCustomerWholesaleAdveretDownVoteCommandResponse : CommandResponseBase<CorporateCustomerWholesaleAdvertVoteDto>
    {
        public CreateCorporateCustomerWholesaleAdveretDownVoteCommandResponse(IContentResponse<CorporateCustomerWholesaleAdvertVoteDto> response) : base(response)
        {
        }
    }
}
