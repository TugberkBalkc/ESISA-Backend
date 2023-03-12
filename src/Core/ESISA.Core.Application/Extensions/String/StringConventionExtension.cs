using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Extensions.String
{
    public static class StringConventionExtension
    {
        public static string GetTrimmedLowered(this string @string)
        {
            return @string.Trim().ToLower();
        }
    }
}
