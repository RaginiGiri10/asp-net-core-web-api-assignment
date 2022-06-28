using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarsAPI.Models
{
    public class Car
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(20)]
        [Required]
        public string Name { get; set; }
        [MaxLength(50)]
        [Required]
        public string Category { get; set; }
       
        [Required]
        public int Price { get; set; }
      

    }
}
