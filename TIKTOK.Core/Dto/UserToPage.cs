using System;
using System.Collections.Generic;
using System.Text;

namespace TIKTOK.Core.Dto
{
    public class UserToPage
    {
        public int id { get; set; }
        public string fullName { get; set; }
        public string userName { get; set; }
        public string title { get; set; }
        public string imagePath { get; set; }
        public DateTime bDate { get; set; }
        public int followBack { get; set; }
        public int countLikeTake { get; set; }
        public int countVideos { get; set; }
        public int countFollowing { get; set; }
        public int countFollower { get; set; }

    }
}
