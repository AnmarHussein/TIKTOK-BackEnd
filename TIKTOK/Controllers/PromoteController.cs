using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TIKTOK.Core.Data;
using TIKTOK.Core.Service;

namespace TIKTOK.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PromoteController : ControllerBase
    {
        private readonly IGenericService<PROMOTE> _genericService;

        public PromoteController(IGenericService<PROMOTE> genericService, IGenericService<VISACARD> visaCardService)
        {
            _genericService = genericService;
        }

        // https://localhost:44372/api/PROMOTE [Get] 
        // No Data Pass

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            await Task.Delay(300);
            return Ok(await _genericService.GenericCRUD<List<PROMOTE>>("GETALL", null));
        }

        // https://localhost:44372/api/PROMOTE/GetByID [Get] 
        // DATA FROM Body { "ID" : 1}

        [HttpGet("GetByID")]
        public async Task<IActionResult> GetByID([FromBody] PROMOTE ptype)
        {
            await Task.Delay(300);
            return Ok(await _genericService.GenericCRUD<PROMOTE>("GETBYID", ptype));
        }


        //https://localhost:44372/api/PROMOTE   [POST]
        //DATA FROM Body { "NAME" : "IT Oracle"}

        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] PROMOTE ptype)
        {
            await Task.Delay(300);
            ptype.createAt = DateTime.Now;
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(await _genericService.GenericCRUD<string>("INSERT", ptype));
        }

        //https://localhost:44372/api/PROMOTE   [PUT]
        //DATA FROM Body { "ID" : 2,"NAME" : "IT New Oracle"}
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] PROMOTE ptype)
        {
            await Task.Delay(300);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(await _genericService.GenericCRUD<string>("UPDATE", ptype));
        }

        //https://localhost:44372/api/PROMOTE   [Delete]
        //DATA FROM Body { "ID" : 2}
        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] PROMOTE ptype)
        {
            await Task.Delay(300);
            var exi = await _genericService.GenericCRUD<PROMOTE>("GETBYID", ptype);
            if (!ModelState.IsValid || exi == null)
            {
                return BadRequest(ModelState);
            }

            return Ok(await _genericService.GenericCRUD<string>("DELETE", ptype));
        }
    }
}
