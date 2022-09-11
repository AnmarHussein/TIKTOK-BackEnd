using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TIKTOK.Core.Data
{
    public class HomePage
    {
        [Required]
        public int id { get; set; }
        [Required]
        public string captur1 { get; set; }
        [Required]
        public string captur2 { get; set; }
        [Required]
        public string captur3 { get; set; }
        [Required]
        public string pargraf1 { get; set; }
        [Required]
        public string button1 { get; set; }
        [Required]
        public string pargraf2 { get; set; }
        [Required]
        public string copyRigth { get; set; }
        [Required]
        public string navLogo { get; set; }
        [Required]
        public string navButton1 { get; set; }
        [Required]
        public string navButton2 { get; set; }

    }
}
