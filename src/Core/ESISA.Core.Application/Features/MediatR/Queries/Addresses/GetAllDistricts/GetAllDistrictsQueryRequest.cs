﻿using ESISA.Core.Application.Features.MediatR.Queries.Addresses.GetAllCities;
using ESISA.Core.Application.Features.MediatR.Requests.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Features.MediatR.Queries.Addresses.GetAllDistricts
{
    public class GetAllDistrictsQueryRequest : IRequest<GetAllDistrictsQueryResponse>, IPageableQueryRequest
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public GetAllDistrictsQueryRequest()
        {


        }
        public GetAllDistrictsQueryRequest(int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;  
            PageSize = pageSize;    
        }
    }
}
