using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace Electremia.ViewModels
{
    public class ProductViewModel : ContentViewModel
    {
        [Required]
        [RegularExpression(@"\d+(\.\d{1,2})?", ErrorMessage = "Invalid price")]
        public decimal Price { get; set; }
        public List<IFormFile> Picture { get; set; }
    }
}