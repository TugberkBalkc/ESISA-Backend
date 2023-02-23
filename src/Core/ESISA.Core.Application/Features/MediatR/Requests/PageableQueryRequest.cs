using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Features.MediatR.Requests
{
    public class PageableQueryRequest
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }

        public PageableQueryRequest()
        {

        }

        public PageableQueryRequest(int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
        }
    }
}
