namespace CodeAlpha_Restaurant_Management_SystemAPI.Models
{
    public class OrderMenuItem
    {
        public int OrderId { get; set; }
        public Order Order { get; set; }

        public int MenuItemId { get; set; }
        public MenuItem MenuItem { get; set; }
    }
}
