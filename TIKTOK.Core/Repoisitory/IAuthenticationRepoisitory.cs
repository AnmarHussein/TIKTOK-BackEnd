using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TIKTOK.Core.Dto;

namespace TIKTOK.Core.Repoisitory
{
    public interface IAuthenticationRepoisitory
    {
        public Task<AuthUserDto> GetUserAuth(LoginDto login);
        public Task<string> ConfirmEmail(string userName);
        public Task<string> ForgetPassWord(AuthUserDto user);
    }
}
