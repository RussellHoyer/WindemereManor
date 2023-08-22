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
        private readonly WindemereManorWebContext _context;

        public CreateModel(WindemereManorWebContext context)
        {
            _context = context;
            FridgeItem = new();
        }

        public IActionResult OnGet()
        {
            // Defaults
            FridgeItem.AddedOn = DateTime.Now;
            FridgeItem.Expiration = DateTime.Now.AddDays(7);

            LocationChoices = new SelectList(new List<string>
            {
                "Upstairs",
                "Downstairs"
            });

            return Page();
        }

        [BindProperty]
        public FridgeItem FridgeItem { get; set; } = default!;
        [BindProperty]
        public string SelectedLocation { get; set; }
        public SelectList LocationChoices { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.FridgeItems == null || FridgeItem == null)
            {
                return Page();
            }
            FridgeItem.Location = SelectedLocation;

            _context.FridgeItems.Add(FridgeItem);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
