using ESISA.Core.Application.Features.MediatR.Requests.Common;
using ESISA.Core.Application.Utilities.Response.Common;

namespace ESISA.Core.Application.Features.MediatR.Commands.Comments.ToAdvert.DeleteCorporateAdvertComment
{
    public class DeleteIndividualCustomerCorporateAdvertCommentCommandResponse : CommandResponseBase<Guid>
    {
        public DeleteIndividualCustomerCorporateAdvertCommentCommandResponse(IContentResponse<Guid> response) : base(response)
        {
        }
    }
}
