using ESISA.Core.Application.Dtos.Adress;
using ESISA.Core.Application.Features.MediatR.Requests.Common;
using ESISA.Core.Application.Utilities.Paging;
using ESISA.Core.Application.Utilities.Response.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Features.MediatR.Queries.Addresses.GetAllAdresses
{
    public class GetAllAdressesQueryResponse : PluralQueryResponse<AdressDto>
    {
        public GetAllAdressesQueryResponse(IContentResponse<IPaginate<AdressDto>> response) : base(response)
        {

        }
    
    
    }
}
