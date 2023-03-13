using ESISA.Core.Application.Dtos.Product;
using ESISA.Core.Application.Features.MediatR.Requests.Common;
using ESISA.Core.Application.Utilities.Response.Common;

namespace ESISA.Core.Application.Features.MediatR.Commands.Products.Update
{
    public class UpdateProductCommandResponse : CommandResponseBase<ProductDto>
    {
        public UpdateProductCommandResponse(IContentResponse<ProductDto> response) : base(response)
        {
        }
    }
}
