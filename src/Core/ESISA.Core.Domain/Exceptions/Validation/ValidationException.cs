using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Domain.Exceptions.Validation
{
    public class ValidationException : Exception
    {
        public ValidationException(String title, String message) : base(title + ',' + message)
        {
        }
    }
}
