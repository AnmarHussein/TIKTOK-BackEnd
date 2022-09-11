using System;
using System.Collections.Generic;
using System.Text;

namespace TIKTOK.Core.Dto
{
    public class PromoteUserDto
    {
        public double amount { get; set; }
        public string securityCode { get; set; }
        public string cardNumber { get; set; }
        public int videoId { get; set; }
        public int promoteTypeId  { get; set; }

    }
}
