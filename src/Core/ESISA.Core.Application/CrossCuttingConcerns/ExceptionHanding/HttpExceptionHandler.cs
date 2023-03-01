using ESISA.Core.Application.Constants.Response;
using ESISA.Core.Domain.Exceptions.AuthenticationAndAuthorization;
using ESISA.Core.Domain.Exceptions.Authorization;
using ESISA.Core.Domain.Exceptions.BusinessLogic;
using ESISA.Core.Domain.Exceptions.Database;
using ESISA.Core.Domain.Exceptions.InternalServer;
using ESISA.Core.Domain.Exceptions.Validation;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.CrossCuttingConcerns.ExceptionHanding
{
    public class HttpExceptionHandler
    {
        private readonly RequestDelegate _next;

        public HttpExceptionHandler(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception exception)
            {
                await HandleExceptionAsync(httpContext, exception);
            }
        }

        private async Task HandleExceptionAsync(HttpContext httpContext, Exception exception)
        {
            if (exception.GetType() == typeof(BusinessLogicException))
                await HandleBusinessLogicExceptionAsync(httpContext, exception);
            else if (exception.GetType() == typeof(AuthenticationException))
                await HandleAuthenticationExceptionAsync(httpContext, exception);
            else if (exception.GetType() == typeof(AuthorizationException))
                await HandleAuthenticationExceptionAsync(httpContext, exception);
            else if (exception.GetType() == typeof(DatabaseException))
                await HandleAuthenticationExceptionAsync(httpContext, exception);
            else if (exception.GetType() == typeof(InternalServerException))
                await HandleAuthenticationExceptionAsync(httpContext, exception);
            else if (exception.GetType() == typeof(FluentValidation.ValidationException))
                await HandleAuthenticationExceptionAsync(httpContext, exception);
        }

        private async Task HandleBusinessLogicExceptionAsync(HttpContext httpContext,Exception exception)
        {
            httpContext.Response.StatusCode = Convert.ToInt32(HttpStatusCode.BadRequest);

            BusinessLogicException businessLogicException = (BusinessLogicException)exception;

            String[] exceptionHeaders = businessLogicException.Message.Split(',');

            BusinessLogicExceptionDetails exceptionDetails = new BusinessLogicExceptionDetails(exceptionHeaders[0], exceptionHeaders[1], StatusCodes.Status400BadRequest, _next.Method.Name);

            await httpContext.Response.WriteAsync(exceptionDetails.ToString());
        }

        private async Task HandleAuthenticationExceptionAsync(HttpContext httpContext, Exception exception)
        {
            httpContext.Response.StatusCode = Convert.ToInt32(HttpStatusCode.Unauthorized);

            AuthenticationException authenticationException = (AuthenticationException)exception;

            String[] exceptionHeaders = authenticationException.Message.Split(',');

            AuthenticationExceptionDetails exceptionDetails = new AuthenticationExceptionDetails(exceptionHeaders[0], exceptionHeaders[1], StatusCodes.Status400BadRequest);

            await httpContext.Response.WriteAsync(exceptionDetails.ToString());
        }

        private async Task HandleAuthorizationExceptionAsync(HttpContext httpContext, Exception exception)
        {
            httpContext.Response.StatusCode = Convert.ToInt32(HttpStatusCode.Forbidden);

            AuthorizationException authorizationException = (AuthorizationException)exception;

            String[] exceptionHeaders = authorizationException.Message.Split(',');

            AuthorizationExceptionDetails exceptionDetails = new AuthorizationExceptionDetails(exceptionHeaders[0], exceptionHeaders[1], StatusCodes.Status403Forbidden, exceptionHeaders[2]);

            await httpContext.Response.WriteAsync(exceptionDetails.ToString());
        }

        private async Task HandleDatabaseExceptionAsync(HttpContext httpContext, Exception exception)
        {
            httpContext.Response.StatusCode = Convert.ToInt32(HttpStatusCode.InternalServerError);

            DatabaseException databaseException = (DatabaseException)exception;

            String[] exceptionHeaders = databaseException.Message.Split(',');

            DatabaseExceptionDetails exceptionDetails = new DatabaseExceptionDetails(exceptionHeaders[0], exceptionHeaders[1], StatusCodes.Status400BadRequest, "ESISA_DB");

            await httpContext.Response.WriteAsync(exceptionDetails.ToString());
        }

        private async Task HandleInternalServerExceptionAsync(HttpContext httpContext, Exception exception)
        {
            httpContext.Response.StatusCode = Convert.ToInt32(HttpStatusCode.InternalServerError);

            InternalServerException internalServerException = (InternalServerException)exception;

            String[] exceptionHeaders = internalServerException.Message.Split(',');

            InternalServerExceptionDetails exceptionDetails = new InternalServerExceptionDetails(exceptionHeaders[0], exceptionHeaders[1], StatusCodes.Status400BadRequest, "ESISA_API");

            await httpContext.Response.WriteAsync(exceptionDetails.ToString());
        }

        private async Task HandleValidationExceptionAsync(HttpContext httpContext, Exception exception)
        {
            httpContext.Response.StatusCode = Convert.ToInt32(HttpStatusCode.BadRequest);

            var validationException = (FluentValidation.ValidationException)exception;

            var validationErrors = validationException.Errors;

            var exceptionDetails = new ESISA.Core.Domain.Exceptions.Validation.ValidationExceptionDetails(ResponseTitles.Error, ResponseMessages.ValidationError, StatusCodes.Status400BadRequest, validationErrors);

            await httpContext.Response.WriteAsync(exceptionDetails.ToString());
        }
    }
}
