using System;
using System.Collections.Generic;
using System.Text;

namespace TIKTOK.Core.Data
{
    public class FOLLOWER
    {
        public int id { get; set; }
        public int userId { get; set; }
        public int followed { get; set; }
        public DateTime createAt { get; set; }
    }
}
