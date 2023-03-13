using ESISA.Core.Application.Features.MediatR.Requests.Common;
using ESISA.Core.Application.Utilities.DynamicQuerying.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Features.MediatR.Queries.Products.GetProductDetailsByDynamic
{
    public class GetProductDetailsByDynamicQueryRequest : IRequest<GetProductDetailsByDynamicQueryResponse>, IPageableQueryRequest
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public DynamicQuery DynamicQuery { get; set; }

        public GetProductDetailsByDynamicQueryRequest()
        {

        }

        public GetProductDetailsByDynamicQueryRequest(int pageIndex, int pageSize, DynamicQuery dynamicQuery)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
            DynamicQuery = dynamicQuery;
        }
    }
}
