using ESISA.Core.Application.Options.Database;
using ESISA.Core.Domain.Entities.Payment;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Infrastructure.Persistence.EntityFramework.Contexts.DesignTimeFactory
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ESISADbContext>
    {
        private readonly String _connectionString;
        public DesignTimeDbContextFactory()
        {

        }

        public DesignTimeDbContextFactory(IOptions<SqlServerDatabaseOptions> options)
        {
            _connectionString = options.Value.ConnectionString;
        }

        public ESISADbContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder<ESISADbContext> dbContextOptionsBuilder = new();

            dbContextOptionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=ESISA;Trusted_Connection=True;MultipleActiveResultSets=true;");

            return new(dbContextOptionsBuilder.Options);
        }
    }
}
