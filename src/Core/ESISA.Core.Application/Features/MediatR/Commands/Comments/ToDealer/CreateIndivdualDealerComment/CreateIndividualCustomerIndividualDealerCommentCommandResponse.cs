using ESISA.Core.Application.Dtos.Evaluation.Comments;
using ESISA.Core.Application.Features.MediatR.Requests.Common;

namespace ESISA.Core.Application.Features.MediatR.Commands.Comments.ToDealer.CreateIndivdualDealerComment
{
    public class CreateIndividualCustomerIndividualDealerCommentCommandResponse : CommandResponseBase<IndividualCustomerIndividualDealerCommentDto>
    {
        public CreateIndividualCustomerIndividualDealerCommentCommandResponse(Utilities.Response.Common.IContentResponse<IndividualCustomerIndividualDealerCommentDto> response) : base(response)
        {
        }
    }
}
