using ESISA.Core.Application.Utilities.Response.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Utilities.Response.NoContentResponse
{
    public class UnsuccessfulNoContentResponse : ResponseBase
    {
        public UnsuccessfulNoContentResponse(String title, String message, HttpStatusCode httpStatusCode) : base(title, message, httpStatusCode, false)
        {
        }

        public UnsuccessfulNoContentResponse(String message, HttpStatusCode httpStatusCode) : base(message, httpStatusCode, false)
        {
        }

        public UnsuccessfulNoContentResponse(HttpStatusCode httpStatusCode) : base(httpStatusCode, false)
        {
        }

        public UnsuccessfulNoContentResponse() : base(false)
        {
        }
    }
}
