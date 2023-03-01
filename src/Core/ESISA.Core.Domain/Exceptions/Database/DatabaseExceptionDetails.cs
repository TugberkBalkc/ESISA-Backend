using ESISA.Core.Domain.Exceptions.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Domain.Exceptions.Database
{
    public class DatabaseExceptionDetails : ExceptionDetailsBase
    {
        public String DatabaseName { get; set; }

        public DatabaseExceptionDetails(String title, String detail, int statusCodes, String databaseName)
        {
            this.Title = title;
            this.Detail = detail;
            this.StatusCode = statusCodes;
            this.ThrownDate = DateTime.Now;
            this.DatabaseName = databaseName;
        }


        public override string ToString() => this.GetDetails(this);
    }
}
