using ESISA.Core.Application.Dtos.Product;
using ESISA.Core.Application.Features.MediatR.Requests.Common;
using ESISA.Core.Application.Utilities.Response.Common;

namespace ESISA.Core.Application.Features.MediatR.Queries.Products.GetProductDetailsById
{
    public class GetProductDetailsByIdQueryResponse : SingularQueryResponse<ProductDetailsDto>
    {
        public GetProductDetailsByIdQueryResponse(IContentResponse<ProductDetailsDto> response) : base(response)
        {
        }
    }
}
