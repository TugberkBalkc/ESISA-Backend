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

        public AuthorizationExceptionDetails(String requestedUsersEmail)
        {
            this.ThrownDate = DateTime.Now;
            this.RequestedUsersEmail = requestedUsersEmail;
        }
    }
}
