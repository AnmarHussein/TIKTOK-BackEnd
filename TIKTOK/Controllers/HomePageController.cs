using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;
using TIKTOK.Core.Data;
using TIKTOK.Core.Dto;
using TIKTOK.Core.Service;

namespace TIKTOK.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomePageController : ControllerBase
    {
        private readonly IHomePageService _homePageService;
        public HomePageController(IHomePageService homePageService)
        {
            _homePageService = homePageService;
        }
        [HttpGet("GetHomePage")]
        public async Task<IActionResult> GetHomePage()
        {
            await Task.Delay(100);
            return Ok(await _homePageService.GetHomePage());
        }
        [HttpGet("GetLik1")]
        public async Task<IActionResult> GetLik1()
        {
            await Task.Delay(100);
            return Ok(await _homePageService.GetLik1());
        }

        [HttpPost("GetAllVideoHome")]
        public async Task<IActionResult> GetAllVideoHome([FromBody] USER1 user)
        {
            await Task.Delay(100);
            return Ok(await _homePageService.GetAllVideoHome(user));
        }

        [HttpPost("GetSuggestUser")]
        public async Task<IActionResult> GetSuggestUser([FromBody] USER1 user)
        {
            await Task.Delay(100);
            return Ok(await _homePageService.GetSuggestUser(user));
        }

        [HttpPost("GetAllLikeByVideo")]
        public async Task<IActionResult> GetAllLikeByVideo([FromBody] VIDEO video)
        {
            await Task.Delay(100);
            return Ok(await _homePageService.GetAllLikeByVideo(video));
        }

        [HttpDelete("DeletLike")]
        public async Task<IActionResult> DeletLike([FromBody] LIKE1 like)
        {
            await Task.Delay(100);
            return Ok(await _homePageService.DeletLike(like));
        }

        [HttpPost("GetVideoToPage")]
        public async Task<IActionResult> GetVideoToPage([FromBody] UserCurent user)
        {
            await Task.Delay(100);
            return Ok(await _homePageService.GetVideoToPage(user));
        }

        [HttpPost("GetUserToPage")]
        public async Task<IActionResult> GetUserToPage([FromBody] UserCurent user)
        {
            await Task.Delay(100);
            return Ok(await _homePageService.GetUserToPage(user));
        }

        [HttpPut("UpdateHomePage")]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> UpdateHomePage([FromBody] HomePage home)
        {
            await Task.Delay(100);
            if (!ModelState.IsValid)
            {
                return BadRequest("The Object Contain null Values");
            }

            return Ok(await _homePageService.UpdateHomePage(home));
        }

    }
}
