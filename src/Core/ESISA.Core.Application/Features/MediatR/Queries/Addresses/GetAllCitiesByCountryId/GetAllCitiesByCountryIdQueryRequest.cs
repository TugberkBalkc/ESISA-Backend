using ESISA.Core.Application.Features.MediatR.Queries.Addresses.GetAllCountries;
using ESISA.Core.Application.Features.MediatR.Requests.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Features.MediatR.Queries.Addresses.GetAllCitiesByCountryId
{
    public class GetAllCitiesByCountryIdQueryRequest : IRequest<GetAllCitiesByCountryIdQueryResponse>, IPageableQueryRequest
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }

        public Guid CountryId { get; set; } 
        public GetAllCitiesByCountryIdQueryRequest()
        {

        }
        public GetAllCitiesByCountryIdQueryRequest(int pageIndex, int pageSize, Guid countryId)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
            CountryId = countryId;  
        }
    }
}
