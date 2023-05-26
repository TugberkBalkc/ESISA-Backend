using ESISA.Core.Application.Dtos.Adresses;
using ESISA.Core.Application.Features.MediatR.Requests.Common;
using ESISA.Core.Application.Utilities.Paging;
using ESISA.Core.Application.Utilities.Response.Common;

namespace ESISA.Core.Application.Features.MediatR.Queries.IndividualStarters.GetAllIndividualStartersAddressesDetails
{
    public class GetAllIndividualStartersAddressesDetailsQueryResponse : PluralQueryResponse<AddressDetailsDto>
    {
        public GetAllIndividualStartersAddressesDetailsQueryResponse(IContentResponse<IPaginate<AddressDetailsDto>> response) : base(response)
        {
        }
    }
}
