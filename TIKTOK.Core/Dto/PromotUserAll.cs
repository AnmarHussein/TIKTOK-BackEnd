using System;
using System.Collections.Generic;
using System.Text;

namespace TIKTOK.Core.Dto
{
    public class PromotUserAll
    {
        public int id { get; set; }
        public DateTime createAt { get; set; }
        public double amount { get; set; }
        public int videoId { get; set; }
        public int cardId { get; set; }
        public int promoteTypeId { get; set; }
        public string title { get; set; }
        public string posterPath { get; set; }
        public string cardNumber { get; set; }
        public string userName { get; set; }
        public string imagePath { get; set; }
        public string name { get; set; }
    }
}
