using ESISA.Core.Application.Dtos.Advert.SwapAdvert;
using ESISA.Core.Application.Features.MediatR.Requests.Common;
using ESISA.Core.Application.Utilities.Paging;
using ESISA.Core.Application.Utilities.Response.Common;

namespace ESISA.Core.Application.Features.MediatR.Queries.SwapAdverts.GetSwapAdvertDetailsByCategoryId
{
    public class GetSwapAdvertDetailsByCategoryIdQueryResponse : PluralQueryResponse<SwapAdvertDetailsDto>
    {
        public GetSwapAdvertDetailsByCategoryIdQueryResponse(IContentResponse<IPaginate<SwapAdvertDetailsDto>> response) : base(response)
        {
        }
    }
}
