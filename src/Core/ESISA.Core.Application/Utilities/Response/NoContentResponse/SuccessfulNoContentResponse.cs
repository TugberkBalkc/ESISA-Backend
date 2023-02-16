using ESISA.Core.Application.Utilities.Response.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Utilities.Response.NoContentResponse
{
    public class SuccessfulNoContentResponse : ResponseBase
    {
        public SuccessfulNoContentResponse(String title, String message, HttpStatusCode httpStatusCode) : base(title, message, httpStatusCode, true)
        {
        }

        public SuccessfulNoContentResponse(String message, HttpStatusCode httpStatusCode) : base(message, httpStatusCode, true)
        {
        }

        public SuccessfulNoContentResponse(HttpStatusCode httpStatusCode) : base(httpStatusCode, true)
        {
        }

        public SuccessfulNoContentResponse() : base(true)
        {
        }
    }
}
