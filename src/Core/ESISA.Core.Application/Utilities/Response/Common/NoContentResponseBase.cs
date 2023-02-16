using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Utilities.Response.Common
{
    public class NoContentResponseBase : ResponseBase, IResponse
    {
        public NoContentResponseBase(bool isSucceeded) : base(isSucceeded)
        {
        }

        public NoContentResponseBase(HttpStatusCode httpStatusCode, bool isSucceeded) : base(httpStatusCode, isSucceeded)
        {
        }

        public NoContentResponseBase(string message, HttpStatusCode httpStatusCode, bool isSucceeded) : base(message, httpStatusCode, isSucceeded)
        {
        }

        public NoContentResponseBase(string title, string message, HttpStatusCode httpStatusCode, bool isSucceeded) : base(title, message, httpStatusCode, isSucceeded)
        {
        }
    }
}
