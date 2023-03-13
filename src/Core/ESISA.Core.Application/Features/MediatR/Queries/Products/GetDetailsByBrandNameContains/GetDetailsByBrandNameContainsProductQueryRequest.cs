using ESISA.Core.Application.Features.MediatR.Requests.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Features.MediatR.Queries.Products.GetDetailsByBrandContains
{
    public class GetDetailsByBrandNameContainsProductQueryRequest : IRequest<GetDetailsByBrandNameContainsProductQueryResponse>, IPageableQueryRequest
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public String BrandNameSearchKey { get; set; }

        public GetDetailsByBrandNameContainsProductQueryRequest()
        {

        }

        public GetDetailsByBrandNameContainsProductQueryRequest(int pageIndex, int pageSize, String brandNameSearchKey)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
            BrandNameSearchKey = brandNameSearchKey;
        }
    }
}
