using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Utilities.Response.Common
{
    public interface IResponse
    {
        String Message { get; }
        String Title { get; }
        bool IsSucceeded { get; }
        HttpStatusCode StatusCode { get; }
    }
}
