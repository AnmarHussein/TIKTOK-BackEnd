using System;
using System.Collections.Generic;
using System.Text;

namespace TIKTOK.Core.Data
{
    public class ContactUs
    {
        public int id { get; set; }
        public string fullName { get; set; }
        public string email { get; set; }
        public string subject { get; set; }
        public string message { get; set; }
        public DateTime createAt { get; set; }
        public DateTime? deleteAt { get; set; }
        public int important { get; set; }
        public int readEmail { get; set; }


    }
}
