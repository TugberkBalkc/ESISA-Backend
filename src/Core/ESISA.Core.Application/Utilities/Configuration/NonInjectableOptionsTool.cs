using ESISA.Core.Application.Options.Authentication;
using ESISA.Core.Application.Options.Database;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Utilities.Configuration
{
    public static class NonInjectableOptionsTool
    {
        public static TokenOptions GetTokenOptions(IConfiguration configuration) => configuration.GetSection("TokenOptions").Get<TokenOptions>();
        public static SqlServerDatabaseOptions GetDatabaseOptions(IConfiguration configuration) => configuration.GetSection("SqlServerDatabaseOptions").Get<SqlServerDatabaseOptions>();
    }
}
