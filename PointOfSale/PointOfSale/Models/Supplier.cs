using System.ComponentModel.DataAnnotations;

namespace PointOfSale.Models
{
    public class Supplier
    {
        public int Id { get; set; }

        [Required, StringLength(150)]
        public string Name { get; set; }

        public int Contact { get; set; }

        [Required]
        [StringLength(150)]
        public string Address { get; set; }

    }
}
