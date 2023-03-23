using ESISA.Core.Application.Features.MediatR.Queries.Addresses.GetAllDistricts;
using ESISA.Core.Application.Features.MediatR.Requests.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Features.MediatR.Queries.Addresses.GetAllDistrictsByCityId
{
    public class GetAllDistrictsByCityIdQueryRequest : IRequest<GetAllDistrictsByCityIdQueryResponse>, IPageableQueryRequest
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public Guid CityId { get; set; }
        public GetAllDistrictsByCityIdQueryRequest()
        {


        }
        public GetAllDistrictsByCityIdQueryRequest(int pageIndex, int pageSize, Guid cityId)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
            CityId = cityId;
        }
    
    }
}
