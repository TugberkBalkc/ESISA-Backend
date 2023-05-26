using ESISA.Core.Application.Features.MediatR.Requests.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Features.MediatR.Queries.SwapAdverts.GetAllSwapAdverts
{
    public class GetAllSwapAdvertsQueryRequest : IRequest<GetAllSwapAdvertsQueryResponse>, IPageableQueryRequest
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }

        public GetAllSwapAdvertsQueryRequest()
        {

        }

        public GetAllSwapAdvertsQueryRequest(int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
        }
    }
}
