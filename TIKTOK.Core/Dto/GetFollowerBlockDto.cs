using System;
using System.Collections.Generic;
using System.Text;

namespace TIKTOK.Core.Dto
{
    public class GetFollowerBlockDto
    {
        public string userName { get; set; }     
        public int id { get; set; }
        public int userId { get; set; }
        public int followed { get; set; }
        public DateTime createAt { get; set; }
        public int followBack { get; set; }
        public int blockedUser { get; set; }
        public string imagePath { get; set; }

    }
}
