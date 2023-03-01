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
        public AuthenticationExceptionDetails(String title, String detail, int statusCodes)
        {
            this.Title = title;
            this.Detail = detail;
            this.StatusCode = statusCodes;
            this.ThrownDate = DateTime.Now;
        }

        public override string ToString() => this.GetDetails(this);
    }
}
