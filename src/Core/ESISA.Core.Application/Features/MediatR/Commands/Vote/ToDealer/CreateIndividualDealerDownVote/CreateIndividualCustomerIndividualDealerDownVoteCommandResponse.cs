using ESISA.Core.Application.Dtos.Evaluation.Votes;
using ESISA.Core.Application.Features.MediatR.Requests.Common;
using ESISA.Core.Application.Utilities.Response.Common;

namespace ESISA.Core.Application.Features.MediatR.Commands.Vote.ToDealer.CreateIndividualDealerDownVote
{
    public class CreateIndividualCustomerIndividualDealerDownVoteCommandResponse : CommandResponseBase<IndividualCustomerIndividualDealerVoteDto>
    {
        public CreateIndividualCustomerIndividualDealerDownVoteCommandResponse(IContentResponse<IndividualCustomerIndividualDealerVoteDto> response) : base(response)
        {
        }
    }
}
