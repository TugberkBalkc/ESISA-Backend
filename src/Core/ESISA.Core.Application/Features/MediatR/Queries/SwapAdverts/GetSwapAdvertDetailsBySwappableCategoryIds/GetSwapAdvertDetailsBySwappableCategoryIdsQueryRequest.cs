using ESISA.Core.Application.Features.MediatR.Requests.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Features.MediatR.Queries.SwapAdverts.GetSwapAdvertDetailsBySwappableCategoryIds
{
    public class GetSwapAdvertDetailsBySwappableCategoryIdsQueryRequest : IRequest<GetSwapAdvertDetailsBySwappableCategoryIdsQueryResponse>, IPageableQueryRequest
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }

        public Guid[] SwappableCategoryIds { get; set; }

        public GetSwapAdvertDetailsBySwappableCategoryIdsQueryRequest()
        {

        }

        public GetSwapAdvertDetailsBySwappableCategoryIdsQueryRequest(int pageIndex, int pageSize, Guid[] swappableCategoryIds)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
            SwappableCategoryIds = swappableCategoryIds;
        }
    }
}
