using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TIKTOK.Core.Dto;

namespace TIKTOK.Core.Service
{
    public interface IEmailService
    {
        public Task<string> SendEmailWebToUser(SendEmailDto email);
        public Task<string> SendEmailRepotToAdmin(SendEmailDto email);
        public Task<string> SendEmailBlockVideo(SendEmailDto email);
        public Task<string> SendEmailBlockUser(SendEmailDto email);
        public Task<string> SendEmailConfirmEmail(SendEmailDto email);
        public Task<string> SendForgetPassWord(SendEmailDto email);
    }
}
