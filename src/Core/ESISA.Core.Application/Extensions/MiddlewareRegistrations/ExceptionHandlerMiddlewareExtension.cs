using ESISA.Core.Application.CrossCuttingConcerns.ExceptionHanding;
using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Extensions.MiddlewareRegistrations
{
    public static class ExceptionHandlerMiddlewareExtension
    {
        public static void UseHttpExceptionHandlerMiddleware(this IApplicationBuilder applicationBuilder)
        {
            applicationBuilder.UseMiddleware<HttpExceptionHandler>();
        }
    }
}
