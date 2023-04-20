using ESISA.Core.Application.Dtos.Advert.IndividualAdverts;
using ESISA.Core.Application.Features.MediatR.Requests.Common;
using ESISA.Core.Application.Utilities.Paging;
using ESISA.Core.Application.Utilities.Response.Common;

namespace ESISA.Core.Application.Features.MediatR.Queries.IndividualAdverts.GetAllIndividualAdverts
{
    public class GetAllIndividualAdvertsQueryResponse : PluralQueryResponse<IndividualAdvertDto>
    {
        public GetAllIndividualAdvertsQueryResponse(IContentResponse<IPaginate<IndividualAdvertDto>> response) : base(response)
        {
        }
    }
}
