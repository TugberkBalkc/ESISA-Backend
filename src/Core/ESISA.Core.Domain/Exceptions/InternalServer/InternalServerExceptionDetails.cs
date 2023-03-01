using ESISA.Core.Domain.Exceptions.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Domain.Exceptions.InternalServer
{
    public class InternalServerExceptionDetails : ExceptionDetailsBase
    {
        public String ServerName { get; set; }

        public InternalServerExceptionDetails(String title, String detail, int statusCodes, String serverName)
        {
            this.Title = title;
            this.Detail = detail;
            this.StatusCode = statusCodes;
            this.ThrownDate = DateTime.Now;
            this.ServerName = serverName;
        }

        public override string ToString() => this.GetDetails(this);
    }
}
