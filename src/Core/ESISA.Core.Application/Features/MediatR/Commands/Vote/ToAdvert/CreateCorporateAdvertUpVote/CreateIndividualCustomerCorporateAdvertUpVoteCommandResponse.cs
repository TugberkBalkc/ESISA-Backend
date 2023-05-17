using ESISA.Core.Application.Dtos.Evaluation.Votes;
using ESISA.Core.Application.Features.MediatR.Requests.Common;
using ESISA.Core.Application.Utilities.Response.Common;

namespace ESISA.Core.Application.Features.MediatR.Commands.Votes.ToAdvert.CreateCorporateAdvertUpVote
{
    public class CreateIndividualCustomerCorporateAdvertUpVoteCommandResponse : CommandResponseBase<IndividualCustomerCorporateAdvertVoteDto>
    {
        public CreateIndividualCustomerCorporateAdvertUpVoteCommandResponse(IContentResponse<IndividualCustomerCorporateAdvertVoteDto> response) : base(response)
        {
        }
    }
}
