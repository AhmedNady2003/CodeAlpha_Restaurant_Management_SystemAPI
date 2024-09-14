namespace CodeAlpha_Restaurant_Management_SystemAPI.Models
{
    public class Reservation
    {
        public int ReservationId { get; set; } 
        public string CustomerName { get; set; } 
        public DateTime ReservationDate { get; set; } 
        public int TableNumber { get; set; } 

        public Table Table { get; set; }
    }
}
