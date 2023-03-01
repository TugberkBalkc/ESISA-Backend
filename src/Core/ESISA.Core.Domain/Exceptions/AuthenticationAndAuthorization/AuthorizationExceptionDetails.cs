using ESISA.Core.Domain.Exceptions.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Domain.Exceptions.AuthenticationAndAuthorization
{
    public class AuthorizationExceptionDetails : ExceptionDetailsBase
    {
        public String RequestedUsersEmail { get; set; }

        public AuthorizationExceptionDetails(String title, String detail, int statusCodes, String requestedUsersEmail)
        {
            this.Title = title;
            this.Detail = detail;
            this.StatusCode = statusCodes;
            this.ThrownDate = DateTime.Now;
            this.RequestedUsersEmail = requestedUsersEmail;
        }

        public override string ToString() => this.GetDetails(this);
    }
}
