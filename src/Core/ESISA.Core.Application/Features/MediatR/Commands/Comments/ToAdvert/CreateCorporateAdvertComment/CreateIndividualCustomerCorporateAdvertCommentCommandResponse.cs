using ESISA.Core.Application.Dtos.Evaluation.Comments;
using ESISA.Core.Application.Features.MediatR.Requests.Common;

namespace ESISA.Core.Application.Features.MediatR.Commands.Comments.ToAdvert.CreateCorporateAdvertComment
{
    public class CreateIndividualCustomerCorporateAdvertCommentCommandResponse : CommandResponseBase<IndividualCustomerCorporateAdvertCommentDto>
    {
        public CreateIndividualCustomerCorporateAdvertCommentCommandResponse(Utilities.Response.Common.IContentResponse<IndividualCustomerCorporateAdvertCommentDto> response) : base(response)
        {
        }
    }
}
