using System;
using System.Collections.Generic;
using System.Text;

namespace TIKTOK.Core.Data
{
    public class REPLAY
    {
        public int id { get; set; }
        public string message { get; set; }
        public string imagePath { get; set; }
        public string videoPath { get; set; }
        public DateTime createAt { get; set; }
        public int userId { get; set; }
        public int videoId { get; set; }
    }
}
