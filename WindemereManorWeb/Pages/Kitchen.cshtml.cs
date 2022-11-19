using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WindemereManor.DataLayer.Models;

namespace WindemereManorWeb.Pages
{
    public class KitchenModel : PageModel
    {
        [BindProperty]
        public List<FridgeItem> FridgeItems { get; set; } = new();

        public void OnGet()
        {
            FridgeItems = new()
            {
                new FridgeItem()
                {
                    ItemName = "Taco meat",
                    AddedOn = DateOnly.FromDateTime(DateTime.Now),
                    Expiration = DateOnly.FromDateTime(DateTime.Now.AddDays(7))
                },

                new FridgeItem()
                {
                    ItemName = "Pico de gallo",
                    AddedOn = DateOnly.FromDateTime(DateTime.Now),
                    Expiration = DateOnly.FromDateTime(DateTime.Now.AddDays(7))
                }
            };
        }
    }
}
