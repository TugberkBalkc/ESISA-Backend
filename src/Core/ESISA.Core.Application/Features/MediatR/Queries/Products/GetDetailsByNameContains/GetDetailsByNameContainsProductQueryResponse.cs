using ESISA.Core.Application.Dtos.Product;
using ESISA.Core.Application.Features.MediatR.Requests.Common;
using ESISA.Core.Application.Utilities.Paging;
using ESISA.Core.Application.Utilities.Response.Common;

namespace ESISA.Core.Application.Features.MediatR.Queries.Products.GetDetailsByNameContains
{
    public class GetDetailsByNameContainsProductQueryResponse : PluralQueryResponse<ProductDetailsDto>
    {
        public GetDetailsByNameContainsProductQueryResponse(IContentResponse<IPaginate<ProductDetailsDto>> response) : base(response)
        {
        }
    }
}
