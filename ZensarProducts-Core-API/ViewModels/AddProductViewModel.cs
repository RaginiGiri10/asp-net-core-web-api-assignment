using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ZensarProducts_Core_API.ViewModels
{
    public class AddProductViewModel
    {
        [MaxLength(20)]
        [Required(ErrorMessage = "Name is mandatory")]
        public string Name { get; set; }
        [MaxLength(50)]
        [Required(ErrorMessage = "Description is mandatory")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Amount is mandatory")]
        [Range(5000, 1000000, ErrorMessage = "Amount must be greater than 5000")]
        public double Amount { get; set; }
    }
}
