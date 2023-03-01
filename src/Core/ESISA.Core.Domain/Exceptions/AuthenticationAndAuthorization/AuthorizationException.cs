using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Domain.Exceptions.Authorization
{
    public class AuthorizationException : Exception
    {
        public AuthorizationException(String title, String message, String userEmail) : base(title + ',' + message + ',' + userEmail)
        {

        }
    }
}
