using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WindemereManor.Models;

namespace WindemereManorWeb.Data
{
    public class WindemereManorWebContext : DbContext
    {
        public WindemereManorWebContext (DbContextOptions<WindemereManorWebContext> options)
            : base(options)
        {
        }

        public DbSet<FridgeItem> FridgeItems { get; set; } = default!;

        public IQueryable<FridgeItem> GetFridgeItems(string location)
        {
            return FridgeItems.Where(x => x.Location == location);
        }
    }
}
