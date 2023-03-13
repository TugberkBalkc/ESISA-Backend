using ESISA.Core.Application.Utilities.Response.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Features.MediatR.Requests.Common
{
    public class SingularQueryResponse<T>
    {
        public IContentResponse<T> Response { get; set; }

        public SingularQueryResponse(IContentResponse<T> response)
        {
            Response = response;
        }
    }
}
