using ESISA.Core.Application.Dtos.Advert.SwapAdvert;
using ESISA.Core.Application.Features.MediatR.Queries.SwapAdverts.GetAllSwapAdverts;
using ESISA.Core.Application.Features.MediatR.Requests.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Features.MediatR.Queries.WholesaleAdverts.GetAllWholesaleAdverts
{
    public class GetAllWholesaleAdvertsQueryRequest : IRequest<GetAllWholesaleAdvertsQueryResponse>, IPageableQueryRequest
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }

        public GetAllWholesaleAdvertsQueryRequest()
        {

        }

        public GetAllWholesaleAdvertsQueryRequest(int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
        }
    }
}
