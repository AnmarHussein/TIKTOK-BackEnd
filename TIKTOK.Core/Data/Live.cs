using System;
using System.Collections.Generic;
using System.Text;

namespace TIKTOK.Core.Data
{
    public class Live
    {
        public int id { get; set; }
        public string userName { get; set; }
        public string imagePath { get; set; }
        public string roomName { get; set; }
        public DateTime startLive { get; set; }
        public DateTime? endLive { get; set; }
        public int userId { get; set; }
    }
}
