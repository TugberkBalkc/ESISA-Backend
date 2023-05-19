using ESISA.Core.Application.Features.MediatR.Requests.Common;
using ESISA.Core.Application.Utilities.Response.Common;

namespace ESISA.Core.Application.Features.MediatR.Commands.Comments.ToDealer.DeleteIndivdualDealerComment
{
    public class DeleteIndividualCustomerIndividualDealerCommentCommandResponse : CommandResponseBase<Guid>
    {
        public DeleteIndividualCustomerIndividualDealerCommentCommandResponse(IContentResponse<Guid> response) : base(response)
        {
        }
    }
}
