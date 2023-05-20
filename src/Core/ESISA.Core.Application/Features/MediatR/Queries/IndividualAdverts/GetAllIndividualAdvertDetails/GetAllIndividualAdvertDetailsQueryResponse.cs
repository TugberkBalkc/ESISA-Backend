using ESISA.Core.Application.Dtos.Advert.IndividualAdvert;
using ESISA.Core.Application.Features.MediatR.Requests.Common;
using ESISA.Core.Application.Utilities.Paging;
using ESISA.Core.Application.Utilities.Response.Common;

namespace ESISA.Core.Application.Features.MediatR.Queries.IndividualAdverts.GetAllIndividualAdvertDetails
{
    public class GetAllIndividualAdvertDetailsQueryResponse : PluralQueryResponse<IndividualAdvertDetailsDto>
    {
        public GetAllIndividualAdvertDetailsQueryResponse(IContentResponse<IPaginate<IndividualAdvertDetailsDto>> response) : base(response)
        {
        }
    }
}
