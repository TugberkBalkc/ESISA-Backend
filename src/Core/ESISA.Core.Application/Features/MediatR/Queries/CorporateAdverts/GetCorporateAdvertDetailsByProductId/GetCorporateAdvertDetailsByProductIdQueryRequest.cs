using ESISA.Core.Application.Features.MediatR.Requests.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Features.MediatR.Queries.CorporateAdverts.GetCorporateAdvertDetailsByProductId
{
    public class GetCorporateAdvertDetailsByProductIdQueryRequest : IRequest<GetCorporateAdvertDetailsByProductIdQueryResponse>, IPageableQueryRequest
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }

        public Guid ProductId { get; set; }

        public GetCorporateAdvertDetailsByProductIdQueryRequest()
        {

        }

        public GetCorporateAdvertDetailsByProductIdQueryRequest(int pageIndex, int pageSize, Guid productId)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
            ProductId = productId;
        }
    }
}
