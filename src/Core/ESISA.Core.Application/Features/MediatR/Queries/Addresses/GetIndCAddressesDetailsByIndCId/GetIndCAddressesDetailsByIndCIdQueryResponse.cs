using ESISA.Core.Application.Dtos.Adresses;
using ESISA.Core.Application.Features.MediatR.Requests.Common;
using ESISA.Core.Application.Utilities.Paging;
using ESISA.Core.Application.Utilities.Response.Common;

namespace ESISA.Core.Application.Features.MediatR.Queries.Addresses.GetIndCAddressesDetailsByIndCId
{
    public class GetIndCAddressesDetailsByIndCIdQueryResponse : PluralQueryResponse<IndividualCustomerAddressDetailsDto>
    {
        public GetIndCAddressesDetailsByIndCIdQueryResponse(IContentResponse<IPaginate<IndividualCustomerAddressDetailsDto>> response) : base(response)
        {
        }
    }
}
