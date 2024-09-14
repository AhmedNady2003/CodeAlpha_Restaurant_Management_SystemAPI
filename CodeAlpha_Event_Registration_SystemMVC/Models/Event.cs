using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeAlpha_Event_Registration_SystemMVC.Models
{
    public class Event
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)] // Not Identity / not auto increment
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string Location { get; set; }
        public ICollection<Registration> Registrations { get; set; }
    }
}
