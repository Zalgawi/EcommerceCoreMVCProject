using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CoreMVCEcommerce.Models
{
    public class Size
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Size Name")]
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        public string Code { get; set; }
    }
}
