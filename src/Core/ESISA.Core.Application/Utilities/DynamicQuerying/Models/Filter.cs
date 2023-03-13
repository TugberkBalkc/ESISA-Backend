using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Utilities.DynamicQuerying.Models
{
    public class Filter
    {
        public string Field { get; set; }
        public string Value { get; set; }
        public string? Operator { get; set; }
        public string? Logic { get; set; }

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
