using System.ComponentModel.DataAnnotations;

namespace CarsAPI.ViewModels
{
    public class AddCarViewModel
    {

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
