using ESISA.Core.Application.Features.MediatR.Requests.Common;
using ESISA.Core.Application.Utilities.Response.Common;

namespace ESISA.Core.Application.Features.MediatR.Commands.Comments.ToAdvert.DeleteWholesaleAdvertComment
{
    public class DeleteCorporateCustomerWholesaleAdvertCommentCommandResponse : CommandResponseBase<Guid>
    {
        public DeleteCorporateCustomerWholesaleAdvertCommentCommandResponse(IContentResponse<Guid> response) : base(response)
        {
        }
    }
}
