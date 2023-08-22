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
        private readonly WindemereManorWebContext _context;

        public IndexModel(WindemereManorWebContext context)
        {
            _context = context;
        }

        public IList<FridgeItem> UpstairsFridgeContents { get;set; } = default!;
        public IList<FridgeItem> DownstairsFridgeContents { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.FridgeItems != null)
            {
                UpstairsFridgeContents = await _context.GetFridgeItems("Upstairs").ToListAsync();
                DownstairsFridgeContents = await _context.GetFridgeItems("Downstairs").ToListAsync();
            }
        }
    }
}
