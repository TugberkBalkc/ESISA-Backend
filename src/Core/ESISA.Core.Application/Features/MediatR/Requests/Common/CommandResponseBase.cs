using ESISA.Core.Application.Utilities.Response.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Features.MediatR.Requests.Common
{
    public class CommandResponseBase<TData>
    {
        public IContentResponse<TData> Response { get; set; }

        public CommandResponseBase()
        {

        }
        public CommandResponseBase(IContentResponse<TData> response)
        {
            Response = response;
        }
    }
}
