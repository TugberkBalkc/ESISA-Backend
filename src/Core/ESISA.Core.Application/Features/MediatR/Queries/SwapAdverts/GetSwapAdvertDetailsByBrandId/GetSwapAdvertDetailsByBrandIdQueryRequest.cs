using ESISA.Core.Application.Features.MediatR.Requests.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Features.MediatR.Queries.SwapAdverts.GetSwapAdvertDetailsByBrandId
{
    public class GetSwapAdvertDetailsByBrandIdQueryRequest : IRequest<GetSwapAdvertDetailsByBrandIdQueryResponse>, IPageableQueryRequest
    {
        public int PageIndex { get ; set; }
        public int PageSize { get; set; }

        public Guid BrandId { get; set; }

        public GetSwapAdvertDetailsByBrandIdQueryRequest()
        {

        }

        public GetSwapAdvertDetailsByBrandIdQueryRequest(int pageIndex, int pageSize, Guid brandId)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
            BrandId = brandId;
        }
    }
}
