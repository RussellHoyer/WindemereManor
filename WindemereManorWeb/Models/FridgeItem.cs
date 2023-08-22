using System.ComponentModel.DataAnnotations;

namespace WindemereManor.Models
{
    public class FridgeItem
    {
        public FridgeItem()
        {
            ItemName = "Fridge Item";
        }

        [Key]
        public int ID { get; set; }
        public string ItemName { get; set; }
        public DateTime Expiration { get; set; }
        public DateTime AddedOn { get; set; }
        public string Location { get; set; } = "Upstairs";
    }
}