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
    public class ProfileController : ControllerBase
    {
        private readonly IProfileService _profileService;
        private readonly IEmailService _emailService;
        public ProfileController(IProfileService profileService, IEmailService emailService)
        {
            _profileService = profileService;
            _emailService = emailService;
        }

        [HttpPost("GetAllFollowers")]
        public async Task<IActionResult> GetAllFollowers([FromBody] Followers follow)
        {
            await Task.Delay(300);
            return Ok(await _profileService.GetAllFollowers(follow));
        }

        [HttpPost("GetAllFollowing")]
        public async Task<IActionResult> GetAllFollowing([FromBody] Followers follow)
        {
            await Task.Delay(300);
            return Ok(await _profileService.GetAllFollowing(follow));
        }

        [HttpPost("GetAllVidoesToUser")]
        public async Task<IActionResult> GetAllVidoesToUser([FromBody] VIDEO video)
        {
            await Task.Delay(300);
            return Ok(await _profileService.GetAllVidoesToUser(video));
        }

        [HttpPost("BlockUserAdmin")]
        public async Task<IActionResult> BlockUserAdmin([FromBody] USER1 user)
        {
            await Task.Delay(300);
            if (user.isBlock == 1)
            {
                SendEmailDto email = new SendEmailDto();
                email.email = user.email;
                email.message = user.userName;
                await _emailService.SendEmailBlockUser(email);
            }
            return Ok(new { message = await _profileService.BlockUserAdmin(user) });
        }

        [HttpPost("BlockVideoAdmin")]
        public async Task<IActionResult> BlockVideoAdmin([FromBody] VIDEO video)
        {
            await Task.Delay(300);
            if(video.isBlock == 1)
            {
                var res = await _profileService.GetVideoToBlock(video);
                SendEmailDto email = new SendEmailDto();
                email.email = res.email;
                email.subject = res.title;
                email.message = res.userName;
                await _emailService.SendEmailBlockVideo(email);
            }
           
            return Ok(new { message = await _profileService.BlockVideoAdmin(video) });
        }

        [HttpPost("GetAllReplayVideo")]
        public async Task<IActionResult> GetAllReplayVideo([FromBody] VIDEO video)
        {
            await Task.Delay(300);
            return Ok(await _profileService.GetAllReplayVideo(video));
        }

        [HttpPost("GetAllLikeVideo")]
        public async Task<IActionResult> GetAllLikeVideo([FromBody] VIDEO video)
        {
            await Task.Delay(300);
            return Ok(await _profileService.GetAllLikeVideo(video));
        }

        [HttpPost("GetCountReplayVideo")]
        public async Task<IActionResult> GetCountReplayVideo([FromBody] VIDEO video)
        {
            await Task.Delay(300);
            return Ok(await _profileService.GetCountReplayVideo(video));
        }

        [HttpPost("GetCountLikeVideo")]
        public async Task<IActionResult> GetCountLikeVideo([FromBody] VIDEO video)
        {
            await Task.Delay(300);
            return Ok(await _profileService.GetCountLikeVideo(video));
        }

        [HttpPost("GetAllVideoAndCount")]
        public async Task<IActionResult> GetAllVideoAndCount([FromBody] USER1 user)
        {
            await Task.Delay(300);
            return Ok(await _profileService.GetAllVideoAndCount(user));
        }


    }
}
