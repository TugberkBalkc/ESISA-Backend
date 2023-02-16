using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Utilities.Response.Common
{
    public class ResponseBase : IResponse
    {
        public string Message { get; }

        public string Title { get; }

        public bool IsSucceeded { get; }

        public HttpStatusCode StatusCode { get; }


        public ResponseBase(String title, String message, HttpStatusCode httpStatusCode, bool isSucceeded) : this(message, httpStatusCode, isSucceeded)
        {
            Title = title;
        }

        public ResponseBase(String message, HttpStatusCode httpStatusCode, bool isSucceeded) : this(httpStatusCode, isSucceeded)
        {
            Message = message;
        }

        public ResponseBase(HttpStatusCode httpStatusCode, bool isSucceeded) : this(isSucceeded)
        {
            StatusCode = httpStatusCode;
        }

        public ResponseBase(bool isSucceeded)
        {
            IsSucceeded = isSucceeded;
        }
    }
}
