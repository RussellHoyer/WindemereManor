using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindemereManor.Models;

namespace WindemereManor.DataLayer
{
    public class KitchenContext : DbContext
    {
        public DbSet<FridgeItem> FridgeItems { get; set; }

        public string DbPath { get; }

        public KitchenContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = Path.Join(path, "WindemereManorWeb", "windemere.db");
        }

        // The following configures EF to create a Sqlite database file in the
        // special "local" folder for your platform.
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");
    }
}
