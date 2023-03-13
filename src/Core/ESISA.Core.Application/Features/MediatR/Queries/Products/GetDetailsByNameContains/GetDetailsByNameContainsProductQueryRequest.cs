using ESISA.Core.Application.Features.MediatR.Requests.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Features.MediatR.Queries.Products.GetDetailsByNameContains
{
    public class GetDetailsByNameContainsProductQueryRequest : IRequest<GetDetailsByNameContainsProductQueryResponse>, IPageableQueryRequest
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public String ProductNameSearchKey { get; set; }

        public GetDetailsByNameContainsProductQueryRequest()
        {

        }

        public GetDetailsByNameContainsProductQueryRequest(int pageIndex, int pageSize, String productNameSearchKey)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
            ProductNameSearchKey = productNameSearchKey;
        }
    }
}
