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

        public override string ToString() => this.GetDetails(this);
    }
}
