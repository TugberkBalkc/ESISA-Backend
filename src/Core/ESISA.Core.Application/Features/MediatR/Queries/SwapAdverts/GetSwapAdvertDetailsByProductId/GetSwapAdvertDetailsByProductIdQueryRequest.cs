using ESISA.Core.Application.Features.MediatR.Requests.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Features.MediatR.Queries.SwapAdverts.GetSwapAdvertDetailsByProductId
{
    public class GetSwapAdvertDetailsByProductIdQueryRequest : IRequest<GetSwapAdvertDetailsByProductIdQueryResponse>, IPageableQueryRequest
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }

        public Guid ProductId { get; set; }

        public GetSwapAdvertDetailsByProductIdQueryRequest()
        {

        }

        public GetSwapAdvertDetailsByProductIdQueryRequest(int pageIndex, int pageSize, Guid productId)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
            ProductId = productId;
        }
    }
}
