using ESISA.Core.Application.Dtos.Adress;
using ESISA.Core.Application.Features.MediatR.Requests.Common;
using ESISA.Core.Application.Utilities.Paging;
using ESISA.Core.Application.Utilities.Response.Common;

namespace ESISA.Core.Application.Features.MediatR.Queries.Addresses.GetAllIndCAddressesByIndCId
{
    public class GetAllIndCAddressesByIndCIdQueryResponse : PluralQueryResponse<IndividualCustomerAddressDto>
    {
        public GetAllIndCAddressesByIndCIdQueryResponse(IContentResponse<IPaginate<IndividualCustomerAddressDto>> response) : base(response)
        {
        }
    }
}
