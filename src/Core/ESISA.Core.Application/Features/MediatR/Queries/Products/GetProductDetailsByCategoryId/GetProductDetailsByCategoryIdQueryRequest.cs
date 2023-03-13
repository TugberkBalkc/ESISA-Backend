using ESISA.Core.Application.Features.MediatR.Requests.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Features.MediatR.Queries.Products.GetProductDetailsByCategoryId
{
    public class GetProductDetailsByCategoryIdQueryRequest : IRequest<GetProductDetailsByCategoryIdQueryResponse>, IPageableQueryRequest
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public Guid CategoryId { get; set; }

        public GetProductDetailsByCategoryIdQueryRequest()
        {

        }

        public GetProductDetailsByCategoryIdQueryRequest(int pageIndex, int pageSize, Guid categoryId)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
            CategoryId = categoryId;
        }
    }
}
