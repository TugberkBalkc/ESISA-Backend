using ESISA.Core.Domain.Exceptions.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Domain.Exceptions.AuthenticationAndAuthorization
{
    public class AuthenticationExceptionDetails : ExceptionDetailsBase
    {
        public AuthenticationExceptionDetails()
        {
            this.ThrownDate = DateTime.Now;
        }
    }
}
