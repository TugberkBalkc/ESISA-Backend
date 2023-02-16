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
        public String RequestedOperation { get; set; }
        public String[] RequestedUsersRoles { get; set; }

        public override string ToString() => this.GetDetails(this);
    }
}
