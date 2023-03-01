using ESISA.Core.Domain.Exceptions.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Domain.Exceptions.Validation
{
    public class ValidationExceptionDetails : ExceptionDetailsBase
    {
        public object Errors { get; set; }

        public ValidationExceptionDetails(String title, String detail, int statusCodes, object errors)
        {
            this.Title = title;
            this.Detail = detail;
            this.StatusCode = statusCodes;
            this.ThrownDate = DateTime.Now;
            this.Errors = errors;
        }

        public override string ToString() => base.GetDetails(this);
    }
}
