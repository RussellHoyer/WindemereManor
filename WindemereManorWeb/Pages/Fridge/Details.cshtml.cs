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
    public class DetailsModel : PageModel
    {
        private readonly WindemereManorWeb.Data.WindemereManorWebContext _context;

        public DetailsModel(WindemereManorWeb.Data.WindemereManorWebContext context)
        {
            _context = context;
        }

      public FridgeItem FridgeItem { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.FridgeItems == null)
            {
                return NotFound();
            }

            var fridgeitem = await _context.FridgeItems.FirstOrDefaultAsync(m => m.ID == id);
            if (fridgeitem == null)
            {
                return NotFound();
            }
            else 
            {
                FridgeItem = fridgeitem;
            }
            return Page();
        }
    }
}
