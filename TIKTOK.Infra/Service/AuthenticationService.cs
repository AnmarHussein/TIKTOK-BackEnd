using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TIKTOK.Core.Data;
using TIKTOK.Core.Dto;
using TIKTOK.Core.Repoisitory;
using TIKTOK.Core.Service;

namespace TIKTOK.Infra.Service
{
    public class AuthenticationService: IAuthenticationService
    {
        private readonly IAuthenticationRepoisitory _authentication;
        private readonly IGenericRepoisitory<USER1> _userRepoisitory;
        private readonly IEmailService _emailService;
        private SymmetricSecurityKey _secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("[SECRET Used To Sign And Verify Jwt Token,It can be any string]"));
        private string _audience = "https://localhost:44307/";
        private string _issuer = "https://localhost:44307/";
        public AuthenticationService(IAuthenticationRepoisitory authentication, IGenericRepoisitory<USER1> userRepoisitory, IEmailService emailService)
        {
            _authentication = authentication;
            _userRepoisitory = userRepoisitory;
            _emailService = emailService;
        }
       
        public async Task<string> GetUserAuth(LoginDto login)
        {
            var user  = await _authentication.GetUserAuth(login);
            if(user != null)
            {
                if(user.confirmEmail == 1)
                     return GenerateToken(1, user);

                var Token = GenerateToken(2, new AuthUserDto { userName = user.userName });
                SendEmailDto send = new SendEmailDto();
                send.subject = Token;
                send.email = user.email;
                send.message = user.userName;
                await _emailService.SendEmailConfirmEmail(send);
                return "MustConfirm";
            }
            return null;
           
        }
        public async Task<string> Rigester(USER1 user)
        {
            if (user != null)
            {
                user.roleId = 2;
                user.imagePath = (user.imagePath != null) ? user.imagePath : "4d6ad52b-220a-4f99-8605-1342bea9c15e_4.PNG";
                var userAdd = await _userRepoisitory.GenericCRUD<string>("INSERT",user);
                if(userAdd != null)
                {
                    var Token = GenerateToken(2,new AuthUserDto { userName= user.userName } );
                    SendEmailDto send = new SendEmailDto();
                    send.subject = Token;
                    send.email = user.email;
                    send.message = user.userName;
                    await _emailService.SendEmailConfirmEmail(send);
                    return "Check Your Email To Confirm";
                }
                return "Plz Again After 5 Minutes";
            }
             
            return null;
        }

        public async Task<string> ConfirmEmail(ConfirmToken token)
        {
            var handler = DecodedToken(token.token);
            var userName = handler.Claims.First(x => x.Type == "userName").Value;
            var res =await _authentication.ConfirmEmail(userName);
            return res;
        }

        public async Task<string> SendTokenForgetPassWord(AuthUserDto user)
        {
            SendEmailDto send = new SendEmailDto();
            send.email = user.email;
            send.subject = GenerateToken(3, user);
            return await _emailService.SendForgetPassWord(send);
        }
        public async Task<string> ForgetPassWord(AuthUserDto user)
        {
            // newPassword == Password And Email == Eamil
            var handler = DecodedToken(user.token);
            user.email = handler.Claims.First(x => x.Type == "Email").Value;
            return await _authentication.ForgetPassWord(user);

        }
        public  string ForgetPassword(ConfirmToken token)
        {
            var handler = DecodedToken(token.token);
            var email = handler.Claims.First(x => x.Type == "Email").Value;
            return  email;
        }
        private ClaimsPrincipal DecodedToken(string token)
        {
            var handler = new JwtSecurityTokenHandler().ValidateToken(token
            , new TokenValidationParameters()
            {
                IssuerSigningKey = this._secretKey,
                ValidIssuer = this._issuer,
                ValidateIssuer = true,
                ValidAudience = this._audience,
                ValidateAudience = true,
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero,
            }, out SecurityToken sToken);
            return handler;
        }
        private string GenerateToken(int typeToken, AuthUserDto user)
        {
            var expier = DateTime.Now;
            var claims = new List<Claim>();
            if (user == null)
            {
                return null;
            }
            if (typeToken == 1)
            {
                const string role = "Role";
                claims.Add(new Claim("userName", user.userName));
                claims.Add(new Claim("Email", user.email));
                claims.Add(new Claim("id", user.id.ToString()));
                claims.Add(new Claim("imagePath", user.imagePath));
                claims.Add(new Claim(role, user.roleName));
                claims.Add(new Claim(ClaimTypes.Role, user.roleName));
                expier = DateTime.Now.AddHours(1);
            }
            else if(typeToken == 2)
            {
                claims.Add(new Claim("userName", user.userName));
                expier = DateTime.Now.AddMinutes(7);
            }
            else if(typeToken == 3)
            {
                claims.Add(new Claim("Email", user.email));
                expier = DateTime.Now.AddMinutes(7);
            }

            var signinCredentials = new SigningCredentials(this._secretKey, SecurityAlgorithms.HmacSha256);
            var tokeOptions = new JwtSecurityToken(
                issuer: this._issuer,
                audience: this._audience,
                claims: claims,
                expires: expier,
                signingCredentials: signinCredentials
            );
            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
            return tokenString;
        }

    }
}
