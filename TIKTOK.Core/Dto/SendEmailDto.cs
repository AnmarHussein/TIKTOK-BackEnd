using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace TIKTOK.Core.Dto
{
    public class SendEmailDto
    {
        public string fullName { get; set; }
        public string email { get; set; }
        public string subject { get; set; }
        public string message { get; set; }
        public IFormFile file { get; set; }

    }
}
