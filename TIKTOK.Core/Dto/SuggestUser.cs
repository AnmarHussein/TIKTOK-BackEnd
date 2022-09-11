using System;
using System.Collections.Generic;
using System.Text;

namespace TIKTOK.Core.Dto
{
    public class SuggestUser
    {
        public int id { get; set; }
        public string userName { get; set; }
        public string imagePath { get; set; }
        public int count { get; set; }
    }
}
