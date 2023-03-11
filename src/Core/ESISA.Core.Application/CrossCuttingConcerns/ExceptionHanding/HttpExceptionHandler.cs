using ESISA.Core.Application.Constants.HttpContextConstants;
using ESISA.Core.Application.Constants.Response;
using ESISA.Core.Application.Utilities.Response.ExceptionResponse;
using ESISA.Core.Domain.Constants;
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

        private String _requestedMethodName { get; set; }

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
            httpContext.Response.ContentType = HttpContextConstants.ContentType;
            var requestPathElements = httpContext.Request.Path.Value.Split("/");
            _requestedMethodName = requestPathElements.Last();
            //todo awaitten sonra yazanları düzelt
            switch (exception.GetType().Name)
            {
                case var value when value == typeof(BusinessLogicException).Name:
                    await HandleBusinessLogicExceptionAsync(httpContext, exception);
                    break;
                case var value when value == typeof(AuthenticationException).Name:
                    await HandleAuthenticationExceptionAsync(httpContext, exception);
                    break;
                case var value when value == typeof(AuthorizationException).Name:
                    await HandleAuthorizationExceptionAsync(httpContext, exception);
                    break;
                case var value when value == typeof(DatabaseException).Name:
                    await HandleDatabaseExceptionAsync(httpContext, exception);
                    break;
                case var value when value == typeof(InternalServerException).Name:
                    await HandleInternalServerExceptionAsync(httpContext, exception);
                    break;
                default:
                    await HandleCustomExceptionAsync(httpContext, exception);
                    break;
            }
        }

        private async Task HandleBusinessLogicExceptionAsync(HttpContext httpContext,Exception exception)
        {

            httpContext.Response.StatusCode = Convert.ToInt32(HttpStatusCode.BadRequest);

            BusinessLogicException businessLogicException = (BusinessLogicException)exception;

            String[] exceptionHeaders = businessLogicException.Message.Split(',');

            BusinessLogicExceptionDetails exceptionDetails = new BusinessLogicExceptionDetails(_requestedMethodName);

            ExceptionResponse exceptionResponse = new ExceptionResponse(businessLogicException, exceptionDetails, exceptionHeaders[0], exceptionHeaders[1], HttpStatusCode.BadRequest);

            await httpContext.Response.WriteAsync(exceptionResponse.GetDetails());
        }

        private async Task HandleAuthenticationExceptionAsync(HttpContext httpContext, Exception exception)
        {
            httpContext.Response.StatusCode = Convert.ToInt32(HttpStatusCode.Unauthorized);

            AuthenticationException authenticationException = (AuthenticationException)exception;

            String[] exceptionHeaders = authenticationException.Message.Split(',');

            AuthenticationExceptionDetails exceptionDetails = new AuthenticationExceptionDetails();

            ExceptionResponse exceptionResponse = new ExceptionResponse(authenticationException, exceptionDetails, exceptionHeaders[0], exceptionHeaders[1], HttpStatusCode.BadRequest);

            await httpContext.Response.WriteAsync(exceptionResponse.GetDetails());
        }

        private async Task HandleAuthorizationExceptionAsync(HttpContext httpContext, Exception exception)
        {
            httpContext.Response.StatusCode = Convert.ToInt32(HttpStatusCode.Forbidden);

            AuthorizationException authorizationException = (AuthorizationException)exception;

            String[] exceptionHeaders = authorizationException.Message.Split(',');

            AuthorizationExceptionDetails exceptionDetails = new AuthorizationExceptionDetails(exceptionHeaders[2]);
          
            ExceptionResponse exceptionResponse = new ExceptionResponse(authorizationException, exceptionDetails, exceptionHeaders[0], exceptionHeaders[1], HttpStatusCode.BadRequest);

            await httpContext.Response.WriteAsync(exceptionResponse.GetDetails());
        }

        private async Task HandleDatabaseExceptionAsync(HttpContext httpContext, Exception exception)
        {
            httpContext.Response.StatusCode = Convert.ToInt32(HttpStatusCode.InternalServerError);

            DatabaseException databaseException = (DatabaseException)exception;

            String[] exceptionHeaders = databaseException.Message.Split(',');

            DatabaseExceptionDetails exceptionDetails = new DatabaseExceptionDetails("ESISA_DB");

            ExceptionResponse exceptionResponse = new ExceptionResponse(databaseException, exceptionDetails, exceptionHeaders[0], exceptionHeaders[1], HttpStatusCode.BadRequest);

            await httpContext.Response.WriteAsync(exceptionResponse.GetDetails());
        }

        private async Task HandleInternalServerExceptionAsync(HttpContext httpContext, Exception exception)
        {
            httpContext.Response.StatusCode = Convert.ToInt32(HttpStatusCode.InternalServerError);

            InternalServerException internalServerException = (InternalServerException)exception;

            String[] exceptionHeaders = internalServerException.Message.Split(',');

            InternalServerExceptionDetails exceptionDetails = new InternalServerExceptionDetails("ESISA_API");

            ExceptionResponse exceptionResponse = new ExceptionResponse(internalServerException, exceptionDetails, exceptionHeaders[0], exceptionHeaders[1], HttpStatusCode.BadRequest);

            await httpContext.Response.WriteAsync(exceptionResponse.GetDetails());
        }

        private async Task HandleValidationExceptionAsync(HttpContext httpContext, Exception exception)
        {
            httpContext.Response.StatusCode = Convert.ToInt32(HttpStatusCode.BadRequest);

            var validationException = (FluentValidation.ValidationException)exception;

            var validationErrors = validationException.Errors;

            var exceptionDetails = new ESISA.Core.Domain.Exceptions.Validation.ValidationExceptionDetails(validationErrors);

            ExceptionResponse exceptionResponse = new ExceptionResponse(validationException, exceptionDetails, ResponseTitles.Error, ResponseMessages.ValidationError, HttpStatusCode.BadRequest);

            await httpContext.Response.WriteAsync(exceptionResponse.GetDetails());
        }

        private async Task HandleCustomExceptionAsync(HttpContext httpContext, Exception exception)
        {
            httpContext.Response.StatusCode = Convert.ToInt32(HttpStatusCode.BadRequest);

            ExceptionResponse exceptionResponse = new ExceptionResponse(exception, new Domain.Exceptions.Common.ExceptionDetailsBase() { ThrownDate = DateTime.Now} ,DefaultDomainExceptionTitles.InternalExceptionTitle,exception.Message, HttpStatusCode.BadRequest);

            await httpContext.Response.WriteAsync(exceptionResponse.GetDetails());
        }
    }
}
