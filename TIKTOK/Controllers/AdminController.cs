using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TIKTOK.Core.Dto;
using TIKTOK.Core.Service;

namespace TIKTOK.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _adminService;
        public AdminController(IAdminService adminService)
        {
            _adminService = adminService; 
        }

        [HttpGet("GetSelaesPromote")]
        public async Task<IActionResult> GetSelaesPromote()
        {
            Task.Delay(1000).Wait();
            return Ok(await _adminService.GetSelaesPromote());
        }

        [HttpGet("GetGenderCount")]
        public async Task<IActionResult> GetGenderCount()
        {
            Task.Delay(1000).Wait();
            return Ok(await _adminService.GetGenderCount());
        }

        [HttpGet("GetTopFiveFollowerdUser")]
        public async Task<IActionResult> GetTopFiveFollowerdUser()
        {
            Task.Delay(1000).Wait();
            return Ok(await _adminService.GetTopFiveFollowerdUser());
        }

        [HttpGet("GetTopFivelikevideo")]
        public async Task<IActionResult> GetTopFivelikevideo()
        {
            Task.Delay(1000).Wait();
            return Ok(await _adminService.GetTopFivelikevideo());
        }

        // data from body {"tablename": "like1","cloname":"createat","year":"2022"}
        // return list  Moneth1 => "01" : 8
        [HttpPost("GetAllVideoCountInMonth")]
        public async Task<IActionResult> GetAllVideoCountInMonth(PassDataToProsudeDto monthDto)
        {
            Task.Delay(1000).Wait();
            return Ok(await _adminService.GetAllVideoCountInMonth(monthDto));
        }

        // data from body {"tablename": "like1","cloname":"id"}
        // return list  Moneth1 => "01" : 8
        [HttpPost("GetAlltableCountRow")]
        public async Task<IActionResult> GetAlltableCountRow(PassDataToProsudeDto monthDto)
        {
            Task.Delay(1000).Wait();
            return Ok(await _adminService.GetAlltableCountRow(monthDto));
        }

        [HttpGet("GetAllPromoteInner")]
        public async Task<IActionResult> GetAllPromoteInner()
        {
            Task.Delay(1000).Wait();
            return Ok(await _adminService.GetAllPromoteInner());
        }


    }
}
