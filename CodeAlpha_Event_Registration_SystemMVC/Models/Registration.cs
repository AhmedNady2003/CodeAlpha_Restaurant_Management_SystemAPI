using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeAlpha_Event_Registration_SystemMVC.Models
{
    public class Registration
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)] // Not Identity / not auto increment
        public int Id { get; set; }
        [Required]
        public int EventId { get; set; }
        public Event Event { get; set; }
        [Required]
        public string UserName { get; set; }
        public string Email { get; set; }
    }
}
