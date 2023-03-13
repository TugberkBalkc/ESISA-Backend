using ESISA.Core.Application.Features.MediatR.Requests.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Features.MediatR.Queries.Products.GetDetailsByCategoryNameContains
{

    public class GetDetailsByCategoryNameProductQueryRequest : IRequest<GetDetailsByCategoryNameProductQueryResponse>, IPageableQueryRequest
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public String CategoryNameSearchKey { get; set; }

        public GetDetailsByCategoryNameProductQueryRequest()
        {

        }

        public GetDetailsByCategoryNameProductQueryRequest(int pageIndex, int pageSize, String categoryNameSearchKey)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
            CategoryNameSearchKey = categoryNameSearchKey;
        }
    }
}
