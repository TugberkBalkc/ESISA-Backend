using ESISA.Core.Application.Features.MediatR.Queries.Addresses.GetAllCities;
using ESISA.Core.Application.Features.MediatR.Requests.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Features.MediatR.Queries.Addresses.GetAllAdresses
{
    public class GetAllAdressesQueryRequest : IRequest<GetAllAdressesQueryResponse>, IPageableQueryRequest
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public GetAllAdressesQueryRequest()
        {

        }
        public GetAllAdressesQueryRequest(int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
        }
    
    }
}
