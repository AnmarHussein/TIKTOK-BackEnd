using System;
using System.Collections.Generic;
using System.Text;

namespace TIKTOK.Core.Dto
{
    public class UserStatsticDto
    {
        public int id { get; set; }
        public string fullName { get; set; }
        public string userName { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public string title { get; set; }
        public string imagePath { get; set; }
        public DateTime bDate { get; set; }
        public int isBlock { get; set; }
        public int confirmEmail { get; set; }
        public int roleId { get; set; }
        public int genderId { get; set; }
        public int countFollower { get; set; }
        public int countFollowing { get; set; }
        public int countVideos { get; set; }
        public int countVisacard { get; set; }
        public int countReplay { get; set; }
        public int countLikeTake { get; set; }

    }
}
