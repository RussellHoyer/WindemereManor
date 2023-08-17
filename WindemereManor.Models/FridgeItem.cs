namespace WindemereManor.Models
{
    public class FridgeItem
    {
        public FridgeItem()
        {
            ItemName = "Fridge Item";
        }

        public int ID { get; set; }
        public string ItemName { get; set; }
        public DateOnly Expiration { get; set; }
        public DateOnly AddedOn { get; set; }
    }
}