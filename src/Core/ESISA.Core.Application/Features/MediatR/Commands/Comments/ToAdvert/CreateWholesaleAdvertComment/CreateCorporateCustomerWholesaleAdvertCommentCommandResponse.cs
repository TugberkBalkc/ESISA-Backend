using ESISA.Core.Application.Dtos.Evaluation.Comments;
using ESISA.Core.Application.Features.MediatR.Requests.Common;

namespace ESISA.Core.Application.Features.MediatR.Commands.Comments.ToAdvert.CreateWholesaleAdvertComment
{
    public class CreateCorporateCustomerWholesaleAdvertCommentCommandResponse : CommandResponseBase<CorporateCustomerWholesaleAdvertCommentDto>
    {
        public CreateCorporateCustomerWholesaleAdvertCommentCommandResponse(Utilities.Response.Common.IContentResponse<CorporateCustomerWholesaleAdvertCommentDto> response) : base(response)
        {
        }
    }
}
