using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Electremia.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        [Column(TypeName = "VARCHAR")]
        [StringLength(50)]
        public string Username { get; set; }
        [Required]
        [Column(TypeName = "VARCHAR")]
        [StringLength(50)]
        public string Password { get; set; }
    }
}
