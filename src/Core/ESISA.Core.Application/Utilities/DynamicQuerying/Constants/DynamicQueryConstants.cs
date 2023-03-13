using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Utilities.DynamicQuerying.Constants
{
    public static class DynamicQueryConstants
    {
        public static readonly String[] Sorts = { "asc", "desc" };

        public static readonly String[] Logics = { "and", "or" };

        public static readonly IDictionary<string, string> Operators = new Dictionary<string, string>
        {
            { "eq", "=" },
            { "neq", "!=" },
            { "lt", "<" },
            { "lte", "<=" },
            { "gt", ">" },
            { "gte", ">=" },
            { "isnull", "== null" },
            { "isnotnull", "!= null" },
            { "startswith", "StartsWith" },
            { "endswith", "EndsWith" },
            { "contains", "Contains" },
            { "doesnotcontain", "Contains" }
        };

        public const String DoesNotContainsOperatorKeyName = "doesnotcontain";
        public const String IsNullContainsOperatorKeyName = "isnull";
        public const String IsNotNullContainsOperatorKeyName = "isnotnull";

        public const String StartsWithOperatorValueName = "StartsWith";
        public const String EndsWithOperatorValueName = "EndsWith";
        public const String ContainsOperatorValueName = "Contains";
    }
}
