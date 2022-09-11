using System;
using System.Collections.Generic;
using System.Text;

namespace TIKTOK.Core.Dto
{
    public class EmailSmtpDto
    {
        public string host { get; set; }
        public int port { get; set; }
        public string userName { get; set; }
        public string password { get; set; }
    }
}
