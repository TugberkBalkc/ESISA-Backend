using ESISA.Core.Application.Features.MediatR.Requests.Common;
using ESISA.Core.Application.Utilities.DynamicQuerying;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Features.MediatR.Queries.Products.GetByDynamic
{
    public class GetByDynamicProductQueryRequest : IRequest<GetByDynamicProductQueryResponse>, IPageableQueryRequest
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public DynamicQuery DynamicQuery { get; set; }

        public GetByDynamicProductQueryRequest()
        {

        }

        public GetByDynamicProductQueryRequest(int pageIndex, int pageSize, DynamicQuery dynamicQuery)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
            DynamicQuery = dynamicQuery;
        }
    }
}
