using ESISA.Core.Application.Dtos.Evaluation.Votes;
using ESISA.Core.Application.Features.MediatR.Requests.Common;
using ESISA.Core.Application.Utilities.Response.Common;

namespace ESISA.Core.Application.Features.MediatR.Commands.Vote.ToAdvert.CreateCorporateAdvertDownVote
{
    public class CreateIndividualCustomerCorporateAdvertDownVoteCommandResponse : CommandResponseBase<IndividualCustomerCorporateAdvertVoteDto>
    {
        public CreateIndividualCustomerCorporateAdvertDownVoteCommandResponse(IContentResponse<IndividualCustomerCorporateAdvertVoteDto> response) : base(response)
        {
        }
    }
}
