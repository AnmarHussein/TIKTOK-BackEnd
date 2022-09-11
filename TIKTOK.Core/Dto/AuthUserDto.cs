using System;
using System.Collections.Generic;
using System.Text;

namespace TIKTOK.Core.Dto
{
    public class AuthUserDto
    {
        public int id { get; set; }
        public string userName { get; set; }
        public string imagePath { get; set; }
        public string roleName { get; set; }
        public string email { get; set; }
        public string token { get; set; }
        public int confirmEmail { get; set; }
        public string newPassword { get; set; }
    }
}
