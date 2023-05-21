using ESISA.Core.Application.Features.MediatR.Requests.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Features.MediatR.Queries.CorporateAdverts.GetCorporateAdvertDetailsByDealerId
{
    public class GetCorporateAdvertDetailsByDealerIdQueryRequest : IRequest<GetCorporateAdvertDetailsByDealerIdQueryResponse>, IPageableQueryRequest
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }

        public Guid DealerId { get; set; }

        public GetCorporateAdvertDetailsByDealerIdQueryRequest()
        {

        }

        public GetCorporateAdvertDetailsByDealerIdQueryRequest(int pageIndex, int pageSize, Guid dealerId)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
            DealerId = dealerId;
        }
    }
}
