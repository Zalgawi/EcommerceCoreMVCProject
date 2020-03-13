using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CoreMVCEcommerce.Models
{
    public class Colour
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Colour Name")]
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
    }
}
