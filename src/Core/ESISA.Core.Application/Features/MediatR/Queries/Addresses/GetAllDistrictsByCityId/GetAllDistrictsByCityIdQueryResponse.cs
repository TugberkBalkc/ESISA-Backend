﻿using ESISA.Core.Application.Dtos.Adresses;
using ESISA.Core.Application.Features.MediatR.Queries.Addresses.GetAllDistricts;
using ESISA.Core.Application.Features.MediatR.Requests.Common;
using ESISA.Core.Application.Utilities.Paging;
using ESISA.Core.Application.Utilities.Response.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Features.MediatR.Queries.Addresses.GetAllDistrictsByCityId
{
    public class GetAllDistrictsByCityIdQueryResponse : PluralQueryResponse<DistrictDto>
    {
        public GetAllDistrictsByCityIdQueryResponse(IContentResponse<IPaginate<DistrictDto>> response) : base(response)
        {
        }
    }
    
}
