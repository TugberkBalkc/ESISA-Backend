using ESISA.Core.Application.Features.MediatR.Requests.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Features.MediatR.Queries.WholesaleAdverts.GetallWholesaleAdvertDetails
{
    public class GetAllWholesaleAdvertDetailsQueryRequest : IRequest<GetAllWholesaleAdvertDetailsQueryResponse>, IPageableQueryRequest
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }

        public GetAllWholesaleAdvertDetailsQueryRequest()
        {

        }

        public GetAllWholesaleAdvertDetailsQueryRequest(int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
        }
    }
}
