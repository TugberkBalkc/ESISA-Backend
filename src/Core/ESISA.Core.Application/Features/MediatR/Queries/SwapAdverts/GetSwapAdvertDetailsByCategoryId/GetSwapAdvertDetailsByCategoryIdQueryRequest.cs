using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Features.MediatR.Queries.SwapAdverts.GetSwapAdvertDetailsByCategoryId
{
    public class GetSwapAdvertDetailsByCategoryIdQueryRequest : IRequest<GetSwapAdvertDetailsByCategoryIdQueryResponse>
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }

        public Guid CategoryId { get; set; }

        public GetSwapAdvertDetailsByCategoryIdQueryRequest()
        {

        }

        public GetSwapAdvertDetailsByCategoryIdQueryRequest(int pageIndex, int pageSize, Guid categoryId)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
            CategoryId = categoryId;
        }
    }
}
