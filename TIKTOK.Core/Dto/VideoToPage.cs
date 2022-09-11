using System;
using System.Collections.Generic;
using System.Text;

namespace TIKTOK.Core.Dto
{
    public class VideoToPage
    {
        public int id { get; set; }
        public string title { get; set; }
        public string posterPath { get; set; }
        public string videoPath { get; set; }
        public DateTime createAt { get; set; }
        public int userId { get; set; }
        public int isBlock { get; set; }
        public int countLike { get; set; }
        public int countReplay { get; set; }
        public int LIKEINVIDEO { get; set; }

    }
}
