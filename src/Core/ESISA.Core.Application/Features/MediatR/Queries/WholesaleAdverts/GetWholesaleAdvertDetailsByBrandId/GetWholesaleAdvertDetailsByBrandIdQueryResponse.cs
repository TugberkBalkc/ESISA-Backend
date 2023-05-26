using ESISA.Core.Application.Dtos.Advert.WholesaleAdvert;
using ESISA.Core.Application.Features.MediatR.Requests.Common;
using ESISA.Core.Application.Utilities.Paging;
using ESISA.Core.Application.Utilities.Response.Common;

namespace ESISA.Core.Application.Features.MediatR.Queries.WholesaleAdverts.GetWholesaleAdvertDetailsByBrandId
{
    public class GetWholesaleAdvertDetailsByBrandIdQueryResponse : PluralQueryResponse<WholesaleAdvertDetailsDto>
    {
        public GetWholesaleAdvertDetailsByBrandIdQueryResponse(IContentResponse<IPaginate<WholesaleAdvertDetailsDto>> response) : base(response)
        {
        }
    }
}
