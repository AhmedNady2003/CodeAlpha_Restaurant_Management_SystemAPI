namespace CodeAlpha_Restaurant_Management_SystemAPI.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public int TableNumber { get; set; } 
        public DateTime OrderDate { get; set; } 
        public string Status { get; set; } 

       
        public ICollection<OrderMenuItem> OrderMenuItems { get; set; }
    }
}
