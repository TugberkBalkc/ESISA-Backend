using ESISA.Core.Application.Dtos.Evaluation.Comments;
using ESISA.Core.Application.Features.MediatR.Requests.Common;

namespace ESISA.Core.Application.Features.MediatR.Commands.Comments.ToDealer.CreateCorporateDealerComment
{
    public class CreateCorporateCustomerCorporateDealerCommentCommandResponse : CommandResponseBase<CorporateCustomerCorporateDealerCommentDto>
    {
        public CreateCorporateCustomerCorporateDealerCommentCommandResponse(Utilities.Response.Common.IContentResponse<CorporateCustomerCorporateDealerCommentDto> response) : base(response)
        {
        }
    }
}
