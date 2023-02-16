using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Domain.Exceptions.Common
{
    public class ExceptionDetailsBase
    {
        public String Title { get; set; }
        public String Detail { get; set; }
        public int StatusCode { get; set; }
        public DateTime ThrownDate { get; set; }

        protected String GetDetails(object type) => JsonConvert.SerializeObject(type); 
    }
}
