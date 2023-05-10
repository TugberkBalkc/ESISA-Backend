using ESISA.Core.Application.Dtos.Evaluation.Votes;
using ESISA.Core.Application.Features.MediatR.Requests.Common;
using ESISA.Core.Application.Utilities.Response.Common;

namespace ESISA.Core.Application.Features.MediatR.Commands.Vote.ToDealer.CreateIndividualDealerUpVote
{
    public class CreateIndividualCustomerIndividualDealerUpVoteCommandResponse : CommandResponseBase<IndividualCustomerIndividualDealerVoteDto>
    {
        public CreateIndividualCustomerIndividualDealerUpVoteCommandResponse(IContentResponse<IndividualCustomerIndividualDealerVoteDto> response) : base(response)
        {
        }
    }
}
