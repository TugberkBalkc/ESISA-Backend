using ESISA.Core.Application.Features.MediatR.Requests.Common;
using ESISA.Core.Application.Utilities.Response.Common;

namespace ESISA.Core.Application.Features.MediatR.Commands.Comments.ToDealer.DeleteCorporateDealerComment
{
    public class DeleteCorporateCustomerCorporateDealerCommentCommandResponse : CommandResponseBase<Guid>
    {
        public DeleteCorporateCustomerCorporateDealerCommentCommandResponse(IContentResponse<Guid> response) : base(response)
        {
        }
    }
}
