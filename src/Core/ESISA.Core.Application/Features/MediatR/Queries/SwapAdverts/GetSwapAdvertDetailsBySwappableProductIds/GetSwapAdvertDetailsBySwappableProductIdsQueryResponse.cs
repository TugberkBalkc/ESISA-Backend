using ESISA.Core.Application.Dtos.Advert.SwapAdvert;
using ESISA.Core.Application.Features.MediatR.Requests.Common;
using ESISA.Core.Application.Utilities.Paging;
using ESISA.Core.Application.Utilities.Response.Common;

namespace ESISA.Core.Application.Features.MediatR.Queries.SwapAdverts.GetSwapAdvertDetailsBySwappableProductIds
{
    public class GetSwapAdvertDetailsBySwappableProductIdsQueryResponse : PluralQueryResponse<SwapAdvertDetailsDto>
    {
        public GetSwapAdvertDetailsBySwappableProductIdsQueryResponse(IContentResponse<IPaginate<SwapAdvertDetailsDto>> response) : base(response)
        {
        }
    }
}
