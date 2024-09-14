namespace CodeAlpha_Restaurant_Management_SystemAPI.Models
{
    public class Table
    {
        public int TableId { get; set; } 
        public int TableNumber { get; set; } 
        public int Capacity { get; set; }

        
        public ICollection<Reservation> Reservations { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
