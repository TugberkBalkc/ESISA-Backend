using ESISA.Core.Application.Features.MediatR.Queries.SwapAdverts.GetSwapAdvertDetailsBySwappableCategoryIds;
using ESISA.Core.Application.Features.MediatR.Requests.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Features.MediatR.Queries.SwapAdverts.GetSwapAdvertDetailsBySwappableProductIds
{
    public class GetSwapAdvertDetailsBySwappableProductIdsQueryRequest : IRequest<GetSwapAdvertDetailsBySwappableProductIdsQueryResponse>, IPageableQueryRequest
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }

        public Guid[] ProductIds { get; set; }

        public GetSwapAdvertDetailsBySwappableProductIdsQueryRequest()
        {

        }

        public GetSwapAdvertDetailsBySwappableProductIdsQueryRequest(int pageIndex, int pageSize, Guid[] productIds)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
            ProductIds = productIds;
        }
    }
}
