using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CoreMVCEcommerce.Models
{
    public class EditablePage
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string SectionOe { get; set; }
        public string SectionTwo { get; set; }
        public string SectionThree { get; set; }
        public string SectionFour { get; set; }
        public string Footer { get; set; }

    }
}
