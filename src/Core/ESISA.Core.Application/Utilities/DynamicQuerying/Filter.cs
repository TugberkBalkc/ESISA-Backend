using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Utilities.DynamicQuerying
{
    public class Filter
    {
        public String Field { get; set; }
        public String Value { get; set; }
        public String? Operator { get; set; }
        public String? Logic { get; set; }

        public IEnumerable<Filter>? Filters { get; set; }

        public Filter()
        {

        }

        public Filter(string field, string value, string @operator, string logic, IEnumerable<Filter>? filters)
        {
            Field = field;
            Value = value;
            Operator = @operator;
            Logic = logic;
            Filters = filters;
        }
    }
}
