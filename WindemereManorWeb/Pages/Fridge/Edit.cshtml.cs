﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WindemereManor.Models;
using WindemereManorWeb.Data;

namespace WindemereManorWeb.Pages.Fridge
{
    public class EditModel : PageModel
    {
        private readonly WindemereManorWeb.Data.WindemereManorWebContext _context;

        public EditModel(WindemereManorWeb.Data.WindemereManorWebContext context)
        {
            _context = context;
        }

        [BindProperty]
        public FridgeItem FridgeItem { get; set; }
        [BindProperty]
        public string SelectedLocation { get; set; }
        public SelectList LocationChoices { get; set; }


        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.FridgeItems == null)
            {
                return NotFound();
            }
            LocationChoices = new SelectList(new List<string>
            {
                "Upstairs",
                "Downstairs"
            });

            var fridgeitem =  await _context.FridgeItems.FirstOrDefaultAsync(m => m.ID == id);
            if (fridgeitem == null)
            {
                return NotFound();
            }
            FridgeItem = fridgeitem;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(FridgeItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FridgeItemExists(FridgeItem.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool FridgeItemExists(int id)
        {
          return (_context.FridgeItems?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
