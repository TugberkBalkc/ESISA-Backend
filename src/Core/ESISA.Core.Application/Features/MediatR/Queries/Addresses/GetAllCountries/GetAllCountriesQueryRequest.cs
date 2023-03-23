using ESISA.Core.Application.Features.MediatR.Queries.Addresses.GetAllCities;
using ESISA.Core.Application.Features.MediatR.Requests.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Features.MediatR.Queries.Addresses.GetAllCountries
{
    public class GetAllCountriesQueryRequest : IRequest<GetAllCountriesQueryResponse>, IPageableQueryRequest
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public GetAllCountriesQueryRequest()
        {

        }
        public GetAllCountriesQueryRequest(int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;  
            PageSize = pageSize;    

        }
    }
}
