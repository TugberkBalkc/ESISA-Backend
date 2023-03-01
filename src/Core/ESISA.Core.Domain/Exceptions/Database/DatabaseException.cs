using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Domain.Exceptions.Database
{
    public class DatabaseException : Exception
    {
        public DatabaseException(String title, String message) : base(title + ',' + message)
        {
        }
    }
}
