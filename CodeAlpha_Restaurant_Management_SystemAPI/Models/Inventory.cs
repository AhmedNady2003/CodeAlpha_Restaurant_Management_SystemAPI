namespace CodeAlpha_Restaurant_Management_SystemAPI.Models
{
    public class Inventory
    {
        public int InventoryId { get; set; } 
        public string IngredientName { get; set; } 
        public int Quantity { get; set; } 
        public string Unit { get; set; } 

       
        public ICollection<MenuItem> MenuItems { get; set; }
    }
}
