using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CoreMVCEcommerce.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        [Range(1, 10000)]
        public double ListPrice { get; set; }
        [Required]
        [Range(1, 10000)]
        public double Price { get; set; }
        [Required]
        [Range(1, 10000)]
        public double Price50 { get; set; }
        [Required]
        [Range(1, 10000)]
        public double Price100 { get; set; }
        public string ImageUrl { get; set; }
        [Required]
        public int SizeId { get; set; }
        [ForeignKey("SizeId")]
        public Size Size { get; set; }
        [Required]
        public int ColourId { get; set; }
        [ForeignKey("ColourId")]
        public Colour Colour { get; set; }
    }
}
