using ESISA.Core.Application.Features.MediatR.Requests.Common;
using ESISA.Core.Application.Utilities.Response.Common;

namespace ESISA.Core.Application.Features.MediatR.Commands.Products.Delete
{
    public class DeleteProductCommandRespone : CommandResponseBase<Guid>
    {
        public DeleteProductCommandRespone(IContentResponse<Guid> response) : base(response)
        {
        }
    }
}
