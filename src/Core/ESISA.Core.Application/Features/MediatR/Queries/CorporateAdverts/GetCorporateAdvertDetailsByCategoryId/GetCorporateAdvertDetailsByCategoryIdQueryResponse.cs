using ESISA.Core.Application.Dtos.Advert.CorporateAdvert;
using ESISA.Core.Application.Features.MediatR.Requests.Common;
using ESISA.Core.Application.Utilities.Paging;
using ESISA.Core.Application.Utilities.Response.Common;

namespace ESISA.Core.Application.Features.MediatR.Queries.CorporateAdverts.GetCorporateAdvertDetailsByCategoryId
{
    public class GetCorporateAdvertDetailsByCategoryIdQueryResponse : PluralQueryResponse<CorporateAdvertDetailsDto>
    {
        public GetCorporateAdvertDetailsByCategoryIdQueryResponse(IContentResponse<IPaginate<CorporateAdvertDetailsDto>> response) : base(response)
        {
        }
    }

}
