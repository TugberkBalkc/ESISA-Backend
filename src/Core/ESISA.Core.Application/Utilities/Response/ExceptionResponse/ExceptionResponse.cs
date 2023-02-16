using ESISA.Core.Application.Utilities.Response.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Utilities.Response.ExceptionResponse
{
    public class ExceptionResponse : IExceptionResponse
    {
        public Exception Error { get; }

        public string Message { get { return this.Error.Message; } }

        public string Title { get; }

        public bool IsSucceeded { get { return false; } }

        public HttpStatusCode StatusCode { get; }

        public ExceptionResponse(Exception error, string title, HttpStatusCode statusCode)
        {
            Error = error;
            Title = title;
            StatusCode = statusCode;
        }
    }
}
