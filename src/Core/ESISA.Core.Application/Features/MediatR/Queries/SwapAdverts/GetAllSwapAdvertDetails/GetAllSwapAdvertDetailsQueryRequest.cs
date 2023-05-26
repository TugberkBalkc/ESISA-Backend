using ESISA.Core.Application.Features.MediatR.Requests.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Features.MediatR.Queries.SwapAdverts.GetAllSwapAdvertDetails
{
    public class GetAllSwapAdvertDetailsQueryRequest : IRequest<GetAllSwapAdvertDetailsQueryResponse>, IPageableQueryRequest
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }

        public GetAllSwapAdvertDetailsQueryRequest()
        {

        }

        public GetAllSwapAdvertDetailsQueryRequest(int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
        }
    }
}
