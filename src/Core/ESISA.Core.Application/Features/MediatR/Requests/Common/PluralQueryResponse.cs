using ESISA.Core.Application.Utilities.Paging;
using ESISA.Core.Application.Utilities.Response.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Features.MediatR.Requests.Common
{
    public class PluralQueryResponse<T>
    {
        public IContentResponse<IPaginate<T>> Response { get; set; }

        public PluralQueryResponse(IContentResponse<IPaginate<T>> response)
        {
            Response = response;
        }
    }
}
