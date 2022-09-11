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
    public class ProfileUserController : ControllerBase
    {
        private readonly IProfileUserService _profileUserService;
        
        public ProfileUserController(IProfileUserService profileUserService)
        {
            _profileUserService = profileUserService;
        }

        [HttpPost("GetAllFollwerBlock")]
        public async Task<IActionResult> GetAllFollwerBlock([FromBody] USER1 user)
        {
            return Ok(await _profileUserService.GetAllFollwerBlock(user));
        }
        [HttpPost("GetAllFollwingBlock")]
        public async Task<IActionResult> GetAllFollwingBlock([FromBody] USER1 user)
        {
            return Ok(await _profileUserService.GetAllFollwingBlock(user));
        }

        [HttpPost("GetAllUserCountStatistic")]
        public async Task<IActionResult> GetAllUserCountStatistic([FromBody] USER1 user)
        {
            return Ok(await _profileUserService.GetAllUserCountStatistic(user));
        }

        [HttpPost("GetAllVideoLikeReplayCount")]
        public async Task<IActionResult> GetAllVideoLikeReplayCount([FromBody] USER1 user)
        {
            return Ok(await _profileUserService.GetAllVideoLikeReplayCount(user));
        }

        [HttpPost("GetVisaCardCountSumSaeles")]
        public async Task<IActionResult> GetVisaCardCountSumSaeles([FromBody] USER1 user)
        {
            return Ok(await _profileUserService.GetVisaCardCountSumSaeles(user));
        }

        [HttpPost("GetVisaCardByUser")]
        public async Task<IActionResult> GetVisaCardByUser([FromBody] USER1 user)
        {
            return Ok(await _profileUserService.GetVisaCardByUser(user));
        }

        [HttpPost("GetAllPromotVideoByUser")]
        public async Task<IActionResult> GetAllPromotVideoByUser([FromBody] USER1 user)
        {
            return Ok(await _profileUserService.GetAllPromotVideoByUser(user));
        }
        [HttpPost("InsertPromote")]
        public async Task<IActionResult> InsertPromote([FromBody] PromoteUserDto promote)
        {
            return Ok(await _profileUserService.InsertPromote(promote));
        }
        

    }
}
