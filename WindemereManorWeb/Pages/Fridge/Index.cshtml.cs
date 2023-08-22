using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WindemereManor.Models;
using WindemereManorWeb.Data;

namespace WindemereManorWeb.Pages.Fridge
{
    public class IndexModel : PageModel
    {
        private readonly WindemereManorWeb.Data.WindemereManorWebContext _context;

        public IndexModel(WindemereManorWeb.Data.WindemereManorWebContext context)
        {
            _context = context;
        }

        public IList<FridgeItem> FridgeItem { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.FridgeItem != null)
            {
                FridgeItem = await _context.FridgeItem.ToListAsync();
            }
        }
    }
}
