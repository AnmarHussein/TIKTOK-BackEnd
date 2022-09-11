using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TIKTOK.Core.Data;
using TIKTOK.Core.Dto;
using TIKTOK.Core.Service;

namespace TIKTOK.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _auth;
        private readonly IEmailService _email;

        public AuthenticationController(IAuthenticationService auth, IEmailService email)
        {
            _auth = auth;
            _email = email; 
        }

        [HttpPost("Login")]
        public async Task<IActionResult> GetUserAuth([FromBody] LoginDto login)
        {
            if (login is null)
            {
                return Ok("This Value Is Not Valid");
            }
            var res = await _auth.GetUserAuth(login);
            if(res == "MustConfirm")
            {
                return BadRequest("Must Be Confirm Email Check Now Email To Confirm!");
            }    
            if (res != null)
            {
                return Ok(new { Token = res });
            }
            return Unauthorized("The User NAme Or Password Is Not Valid");


        } 
        [HttpPost("Rigester")]
        public async Task<IActionResult> Rigester([FromBody] USER1 user)
        {
            return Ok( await _auth.Rigester(user));
        }

        [HttpPost("ConfirmEmail")]
        public async  Task<IActionResult> ConfirmEmail([FromBody] ConfirmToken token)
        {
            return Ok(await _auth.ConfirmEmail(token));
        }

        [HttpPost("SendTokenForgetPassWord")]
        public async Task<IActionResult> SendTokenForgetPassWord([FromBody] AuthUserDto user)
        {
            if(user.email == null)
            {
                return BadRequest("This Email Not Found");
            }

            return Ok( await _auth.SendTokenForgetPassWord(user));
        }
        [HttpPost("ForgetPassWord")]
        public async Task<IActionResult> ForgetPassWord([FromBody] AuthUserDto user)
        {
            if (user.token == null || user.newPassword == null)
            {
                return BadRequest("This Password Or Email Not Found");
            }

            return Ok(await _auth.ForgetPassWord(user));
        }
    }
}
