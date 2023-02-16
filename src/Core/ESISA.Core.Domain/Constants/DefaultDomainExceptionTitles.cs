using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Domain.Constants
{
    public static class DefaultDomainExceptionTitles
    {
        public const String InternalExceptionTitle = "Internal Server Error";
        public const String BusinessExceptionTitle = "Business Error";
        public const String AuthorizationExceptionTitle = "Authorization Error";
        public const String DatabaseExceptionTitle = "Database Error";
        public const String ValidationExceptionTitle = "Validation Error";
    }
}
