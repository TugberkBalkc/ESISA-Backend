using ESISA.Core.Domain.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Domain.Exceptions.InternalServer
{
    public class InternalServerException : Exception
    {
        public InternalServerException() : base($"{DefaultDomainExceptionTitles.InternalExceptionTitle}{DefaultDomainExceptionMessages.InternalExceptionMessage}")
        {

        }

        public InternalServerException(String message) : base($"{DefaultDomainExceptionTitles.InternalExceptionTitle}:{message}")
        {
        }

        public InternalServerException(String title, String message) : base($"{title}:{message}")
        {
        }
    }
}
