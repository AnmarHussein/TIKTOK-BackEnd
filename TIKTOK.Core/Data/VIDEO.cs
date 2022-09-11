using System;
using System.Collections.Generic;
using System.Text;

namespace TIKTOK.Core.Data
{
    public class VIDEO
    {
        public string userName { get; set; }
        public string imagePath { get; set; }
        public int id { get; set; }
        public string title { get; set; }
        public string posterPath { get; set; }
        public string videoPath { get; set; }
        public DateTime createAt { get; set; }
        public int userId { get; set; }
        public int isBlock { get; set; }
    }
}
