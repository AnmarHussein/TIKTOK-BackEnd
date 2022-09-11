using System;
using System.Collections.Generic;
using System.Text;

namespace TIKTOK.Core.Data
{
    public class VISACARD
    {
        public int id { get; set; }
        public string cardName { get; set; }
        public string cardNumber { get; set; }
        public string expireDate { get; set; }
        public string securityCode { get; set; }
        public int userId { get; set; }
    }
}
