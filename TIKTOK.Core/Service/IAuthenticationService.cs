using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TIKTOK.Core.Data;
using TIKTOK.Core.Dto;

namespace TIKTOK.Core.Service
{
    public interface IAuthenticationService
    {
        public Task<string> GetUserAuth(LoginDto login);
        public Task<string> Rigester(USER1 user);
        public Task<string> ConfirmEmail(ConfirmToken token);
        public Task<string> SendTokenForgetPassWord(AuthUserDto user);
        public Task<string> ForgetPassWord(AuthUserDto user);
    }
}
