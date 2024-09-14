using System.ComponentModel.DataAnnotations.Schema;

namespace CodeAlpha_Restaurant_Management_SystemAPI.Models
{
    public class MenuItem
    {
        public int MenuItemId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        [Column(TypeName = "decimal(18, 2)")] 
        public decimal Price { get; set; }
        public ICollection<OrderMenuItem> OrderMenuItems { get; set; }
    }
}
