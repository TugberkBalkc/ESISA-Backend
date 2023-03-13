using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Features.MediatR.Requests.Common
{
    public interface IPageableQueryRequest
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
    }
}
