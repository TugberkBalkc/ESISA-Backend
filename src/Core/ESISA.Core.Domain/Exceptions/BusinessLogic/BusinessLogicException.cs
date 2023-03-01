using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Domain.Exceptions.BusinessLogic
{
    public class BusinessLogicException : Exception
    {
        public BusinessLogicException(String title, String message) : base(title + "," + message)
        {
        }
    }
}
