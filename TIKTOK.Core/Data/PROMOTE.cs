using System;
using System.Collections.Generic;
using System.Text;

namespace TIKTOK.Core.Data
{
    public class PROMOTE
    {
        public int id { get; set; }
        public DateTime createAt { get; set; }
        public double amount { get; set; }
        public int videoId { get; set; }
        public int cardId { get; set; }
        public int promoteTypeId { get; set; }
    }
}
