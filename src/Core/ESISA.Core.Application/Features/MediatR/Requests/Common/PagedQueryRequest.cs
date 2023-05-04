using ESISA.Core.Application.Constants.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Features.MediatR.Requests.Common
{
    public class PagedQueryRequest
    {
        public int PageSize { get; set; }
        public int PageIndex { get; set; }

        public PagedQueryRequest()
        {

        }

        public PagedQueryRequest(int pageSize, int pageIndex)
        {
            PageSize = pageSize;
            PageIndex = pageIndex;
        }
    }
}
