using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WindemereManor.Models;

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
                    AddedOn = DateTime.Now,
                    Expiration = DateTime.Now.AddDays(7)
                },

                new FridgeItem()
                {
                    ItemName = "Pico de gallo",
                    AddedOn = DateTime.Now,
                    Expiration = DateTime.Now.AddDays(7)
                }
            };
        }
    }
}
