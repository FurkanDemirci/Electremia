using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Electremia.ViewModels
{
    public abstract class ContentViewModel
    {
        [Required]
        [Column(TypeName = "VARCHAR")]
        [StringLength(50)]
        public string Title { get; set; }
        [Required]
        [Column(TypeName = "VARCHAR")]
        public string Description { get; set; }
        //TODO pictures uploaden.
    }
}