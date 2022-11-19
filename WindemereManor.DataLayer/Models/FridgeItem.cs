namespace WindemereManor.DataLayer.Models;

public class FridgeItem
{
    public FridgeItem()
    {
        ItemName = "Fridge Item";
    }

    public string ItemName { get; set; }
    public DateOnly Expiration { get; set; }
    public DateOnly AddedOn { get; set; }
}