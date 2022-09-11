using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TIKTOK.Core.Data;
using TIKTOK.Core.Service;

namespace TIKTOK.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FollowerController : ControllerBase
    {
        private readonly IGenericService<FOLLOWER> _genericService;
        public FollowerController(IGenericService<FOLLOWER> genericService)
        {
            _genericService = genericService;
        }

        // https://localhost:44372/api/FOLLOWER [Get] 
        // No Data Pass

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            await Task.Delay(300);
            return Ok(await _genericService.GenericCRUD<List<FOLLOWER>>("GETALL", null));
        }

        // https://localhost:44372/api/FOLLOWER/GetByID [Get] 
        // DATA FROM Body { "ID" : 1}

        [HttpGet("GetByID")]
        public async Task<IActionResult> GetByID([FromBody] FOLLOWER follower)
        {
            await Task.Delay(300);
            return Ok(await _genericService.GenericCRUD<FOLLOWER>("GETBYID", follower));
        }


        //https://localhost:44372/api/FOLLOWER   [POST]
        //DATA FROM Body { "NAME" : "IT Oracle"}

        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] FOLLOWER follower)
        {
            await Task.Delay(300);
            follower.createAt = System.DateTime.Now;
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(await _genericService.GenericCRUD<string>("INSERT", follower));
        }

        //https://localhost:44372/api/FOLLOWER   [PUT]
        //DATA FROM Body { "ID" : 2,"NAME" : "IT New Oracle"}
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] FOLLOWER follower)
        {
            await Task.Delay(300);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(await _genericService.GenericCRUD<string>("UPDATE", follower));
        }

        //https://localhost:44372/api/FOLLOWER   [Delete]
        //DATA FROM Body { "ID" : 2}
        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] FOLLOWER follower)
        {
            await Task.Delay(300);
            var exi = await _genericService.GenericCRUD<FOLLOWER>("GETBYID", follower);
            if (!ModelState.IsValid || exi == null)
            {
                return BadRequest(ModelState);
            }

            return Ok(await _genericService.GenericCRUD<string>("DELETE", follower));
        }
    }
}
