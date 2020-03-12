using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreMVCEcommerce.Models.ViewModels
{
    public class ProductVM
    {
        public Product Product { get; set; }
        public IEnumerable<SelectListItem> SizeList { get; set; }
        public IEnumerable<SelectListItem> ColourList { get; set; }
    }
}
