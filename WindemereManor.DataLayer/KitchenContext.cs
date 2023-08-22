using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;
using WindemereManor.Models;

namespace WindemereManor.DataLayer
{
    public class KitchenContext : DbContext
    {
        readonly IConfiguration _configuration;
        public DbSet<FridgeItem> FridgeItems { get; set; }

        public KitchenContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // The following configures EF to create a Sqlite database file in the
        // special "local" folder for your platform.
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            base.OnConfiguring(options);
            DbSettings dbSettings = _configuration.GetSection("DbSettings").Get<DbSettings>();
            var conStrBuilder = new SqlConnectionStringBuilder(_configuration.GetConnectionString("DVCPContext"))
            {
                UserID = dbSettings.DVCPDbUser,
                Password = dbSettings.DVCPDbPass
            };

            options.UseSqlServer(conStrBuilder.ConnectionString);
        }
    }
}
