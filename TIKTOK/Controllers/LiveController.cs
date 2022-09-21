using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TIKTOK.Core.Data;
using TIKTOK.Core.Service;

namespace TIKTOK.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LiveController : ControllerBase
    {
        private readonly ILiveService _liveService;
        public LiveController(ILiveService liveService)
        {
            _liveService = liveService;
        }

        [HttpGet("GetActiveLive")]
        public async Task<IActionResult> GetActiveLive()
        {
            Task.Delay(1000).Wait();
            return Ok(await _liveService.GetActiveLive());
        }

        [HttpPost("AddLive")]
        public async Task<IActionResult> AddLive([FromBody] Live live)
        {
            Task.Delay(1000).Wait();
            live.startLive = System.DateTime.Now;
            return Ok(new { message = await _liveService.AddLive(live) });
        }

        [HttpPut("EndLive")]
        public async Task<IActionResult> EndLive([FromBody] Live live)
        {
            Task.Delay(1000).Wait();
            live.endLive = System.DateTime.Now; 
            return Ok(await _liveService.EndLive(live));
        }

    }
}
