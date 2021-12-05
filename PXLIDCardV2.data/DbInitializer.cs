using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Polly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PXLIDCardV2.data
{
    internal class DbInitializer
    {
        private readonly Context _context;
        private readonly ILogger<DbInitializer> _logger;

        public DbInitializer(Context context, ILogger<DbInitializer> logger)
        {
            _context = context;
            _logger = logger;
        }

        public void MigrateDatabase()
        {
            _logger.LogInformation("Migrating database associated with Context");

            try
            {
                var retry = Policy.Handle<SqlException>()
                                .WaitAndRetry(new TimeSpan[]
                                {
                                    TimeSpan.FromSeconds(3),
                                    TimeSpan.FromSeconds(5),
                                    TimeSpan.FromSeconds(8)
                                });
                retry.Execute(() => _context.Database.Migrate());
                _logger.LogInformation("Migrated database associated with Context");
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "An error occurred while migrating the database used on Context");
            }
        }
    }
}
