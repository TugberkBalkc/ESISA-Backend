using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Domain.Exceptions.Database
{
    public class DatabaseException : Exception
    {
        public DatabaseException() : base("Database Exception")
        {
        }

        public DatabaseException(string? message) : base(message)
        {
        }

        public DatabaseException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
