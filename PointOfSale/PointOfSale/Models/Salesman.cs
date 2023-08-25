using System.ComponentModel.DataAnnotations;

namespace PointOfSale.Models
{
    public class Salesman
    {
        public int Id { get; set; }
        [Required]
        public int EmpId { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber), MinLength(11)]
        public int Contact { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
