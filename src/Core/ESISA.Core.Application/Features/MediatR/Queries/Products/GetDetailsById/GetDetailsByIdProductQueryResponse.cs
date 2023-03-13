using ESISA.Core.Application.Dtos.Product;
using ESISA.Core.Application.Features.MediatR.Requests.Common;
using ESISA.Core.Application.Utilities.Response.Common;

namespace ESISA.Core.Application.Features.MediatR.Queries.Products.GetDetailsById
{
    public class GetDetailsByIdProductQueryResponse : SingularQueryResponse<ProductDetailsDto>
    {
        public GetDetailsByIdProductQueryResponse(IContentResponse<ProductDetailsDto> response) : base(response)
        {
        }
    }
}
