using ESISA.Core.Application.Utilities.Response.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Utilities.Response.ContentResponse
{
    public class UnsuccessfulContentResponse<T> : ContentResponseBase<T>
    {
        public UnsuccessfulContentResponse(T content, String title, String message, HttpStatusCode httpStatusCode) : base(content, title, message, httpStatusCode, false)
        {
        }

        public UnsuccessfulContentResponse(String title, String message, HttpStatusCode httpStatusCode) : base(title, message, httpStatusCode, false)
        {
        }

        public UnsuccessfulContentResponse(String message, HttpStatusCode httpStatusCode) : base(message, httpStatusCode, false)
        {
        }

        public UnsuccessfulContentResponse(HttpStatusCode httpStatusCode) : base(httpStatusCode, false)
        {
        }

        public UnsuccessfulContentResponse() : base(false)
        {
        }
    }
}
