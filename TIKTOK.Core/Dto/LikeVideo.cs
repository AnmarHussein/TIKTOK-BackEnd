using System;
using System.Collections.Generic;
using System.Text;

namespace TIKTOK.Core.Dto
{
    public class LikeVideo
    {
        public string userName { get; set; }
        public string imageUserPath { get; set; }
        public int ID { get; set; }
        public int USERID { get; set; }
        public int VIDEOID { get; set; }
        public DateTime CREATEAT { get; set; }
    }
}
