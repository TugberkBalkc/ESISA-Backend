using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Utilities.Response.Common
{
    public class ContentResponseBase<T> : IContentResponse<T>
    {
        public T Content { get; }

        public string Message { get; }

        public string Title { get; }

        public bool IsSucceeded { get; }

        public HttpStatusCode StatusCode { get; }


        public ContentResponseBase(T content, String title, String message, HttpStatusCode httpStatusCode, bool isSucceeded) : this(title, message, httpStatusCode, isSucceeded)
        {
            Content = content;
        }

        public ContentResponseBase(String title, String message, HttpStatusCode httpStatusCode, bool isSucceeded) : this(message, httpStatusCode, isSucceeded)
        {
            Title = title;
        }

        public ContentResponseBase(T content, String message, HttpStatusCode httpStatusCode, bool isSucceeded) : this(message, httpStatusCode, isSucceeded)
        {
            Content = content;
        }

        public ContentResponseBase(String message, HttpStatusCode httpStatusCode, bool isSucceeded) : this(httpStatusCode, isSucceeded)
        {
            Message = message;
        }

        public ContentResponseBase(T content, HttpStatusCode httpStatusCode, bool isSucceeded) : this(httpStatusCode, isSucceeded)
        {
            Content = content;
        }

        public ContentResponseBase(HttpStatusCode httpStatusCode, bool isSucceeded) : this(isSucceeded)
        {
            StatusCode = httpStatusCode;
        }

        public ContentResponseBase(T content, bool isSucceeded) : this(isSucceeded)
        {
            Content = content;
        }

        public ContentResponseBase(bool isSucceeded)
        {
            IsSucceeded = isSucceeded;
        }
    }
}
