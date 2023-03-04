using ESISA.Core.Application.Extensions.ClaimExtensions;
using ESISA.Core.Application.Features.MediatR.Requests.Common;
using ESISA.Core.Domain.Constants;
using ESISA.Core.Domain.Exceptions.Authorization;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Utilities.Pipelines.MediatR.Security.Authorization
{
    public class AuthorizationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>, ISecuredRequest
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AuthorizationBehavior(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var usersRoles = _httpContextAccessor.HttpContext.GetUsersRoles();
            var usersEmail = _httpContextAccessor.HttpContext.GetUsersEmail();

            if (usersRoles is null || usersRoles.Length == 0)
                throw new AuthorizationException(DefaultDomainExceptionTitles.AuthorizationExceptionTitle, DefaultDomainExceptionMessages.AuthorizationExceptionMessage, usersEmail);

            if(this.CheckIfUsersRolesNotSatisfiesRequestsRoles(request, usersRoles) is true)
                throw new AuthorizationException(DefaultDomainExceptionTitles.AuthorizationExceptionTitle, DefaultDomainExceptionMessages.AuthorizationExceptionMessage, usersEmail);

            TResponse response = await next();

            return response;
        }

        private bool CheckIfUsersRolesNotSatisfiesRequestsRoles(TRequest request, String[] usersRoles)
        {
            var result = usersRoles.FirstOrDefault(userRole => request.Roles.Any(requestRole => requestRole == userRole));

            if (result is null || result == String.Empty)
                return true;

            return false;
        }
    }
}

