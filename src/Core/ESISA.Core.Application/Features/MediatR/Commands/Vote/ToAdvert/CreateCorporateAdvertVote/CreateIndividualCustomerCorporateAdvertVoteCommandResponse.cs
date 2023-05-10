using ESISA.Core.Application.Dtos.Evaluation.Votes;
using ESISA.Core.Application.Features.MediatR.Requests.Common;
using ESISA.Core.Application.Utilities.Response.Common;

namespace ESISA.Core.Application.Features.MediatR.Commands.Vote.ToAdvert.CreateCorporateAdvertVote
{
    public class CreateIndividualCustomerCorporateAdvertVoteCommandResponse : CommandResponseBase<IndividualCustomerCorporateAdvertVoteDto>
    {
        public CreateIndividualCustomerCorporateAdvertVoteCommandResponse(IContentResponse<IndividualCustomerCorporateAdvertVoteDto> response) : base(response)
        {
        }
    }
}
