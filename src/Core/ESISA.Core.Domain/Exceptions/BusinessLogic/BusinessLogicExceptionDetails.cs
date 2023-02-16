using ESISA.Core.Domain.Exceptions.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Domain.Exceptions.BusinessLogic
{
    public class BusinessLogicExceptionDetails : ExceptionDetailsBase
    {
        public String OperationName { get; set; }

        public override string ToString() => this.GetDetails(this);
    }
}
