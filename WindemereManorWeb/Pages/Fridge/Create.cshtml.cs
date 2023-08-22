using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WindemereManor.Models;
using WindemereManorWeb.Data;

namespace WindemereManorWeb.Pages.Fridge
{
    public class CreateModel : PageModel
    {
        private readonly WindemereManorWeb.Data.WindemereManorWebContext _context;

        public CreateModel(WindemereManorWeb.Data.WindemereManorWebContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public FridgeItem FridgeItem { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.FridgeItem == null || FridgeItem == null)
            {
                return Page();
            }

            _context.FridgeItem.Add(FridgeItem);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
