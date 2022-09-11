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
    public class Block1Controller : ControllerBase
    {
        private readonly IGenericService<BLOCK1> _genericService;
        public Block1Controller(IGenericService<BLOCK1> genericService)
        {
            _genericService = genericService;
        }

        // https://localhost:44372/api/BLOCK1 [Get] 
        // No Data Pass

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            await Task.Delay(300);
            return Ok(await _genericService.GenericCRUD<List<BLOCK1>>("GETALL", null));
        }

        // https://localhost:44372/api/BLOCK1/GetByID [Get] 
        // DATA FROM Body { "ID" : 1}

        [HttpGet("GetByID")]
        public async Task<IActionResult> GetByID([FromBody] BLOCK1 block1)
        {
            await Task.Delay(300);
            return Ok(await _genericService.GenericCRUD<BLOCK1>("GETBYID", block1));
        }


        //https://localhost:44372/api/BLOCK1   [POST]
        //DATA FROM Body { "NAME" : "IT Oracle"}

        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] BLOCK1 block1)
        {
            await Task.Delay(300);
            block1.createAt = System.DateTime.Now;
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(await _genericService.GenericCRUD<string>("INSERT", block1));
        }

        //https://localhost:44372/api/BLOCK1   [PUT]
        //DATA FROM Body { "ID" : 2,"NAME" : "IT New Oracle"}
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] BLOCK1 block1)
        {
            await Task.Delay(300);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(await _genericService.GenericCRUD<string>("UPDATE", block1));
        }

        //https://localhost:44372/api/BLOCK1   [Delete]
        //DATA FROM Body { "ID" : 2}
        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] BLOCK1 block1)
        {
            await Task.Delay(300);
            var exi = await _genericService.GenericCRUD<BLOCK1>("GETBYID", block1);
            if (!ModelState.IsValid || exi == null)
            {
                return BadRequest(ModelState);
            }

            return Ok(await _genericService.GenericCRUD<string>("DELETE", block1));
        }
    }
}
