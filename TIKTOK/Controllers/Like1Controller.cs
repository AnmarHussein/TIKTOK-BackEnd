﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TIKTOK.Core.Data;
using TIKTOK.Core.Service;

namespace TIKTOK.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Like1Controller : ControllerBase
    {
        private readonly IGenericService<LIKE1> _genericService;
        public Like1Controller(IGenericService<LIKE1> genericService)
        {
            _genericService = genericService;
        }

        // https://localhost:44372/api/LIKE1 [Get] 
        // No Data Pass

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            await Task.Delay(300);
            return Ok(await _genericService.GenericCRUD<List<LIKE1>>("GETALL", null));
        }

        // https://localhost:44372/api/LIKE1/GetByID [Get] 
        // DATA FROM Body { "ID" : 1}

        [HttpGet("GetByID")]
        public async Task<IActionResult> GetByID([FromBody] LIKE1 like)
        {
            await Task.Delay(300);
            return Ok(await _genericService.GenericCRUD<LIKE1>("GETBYID", like));
        }


        //https://localhost:44372/api/LIKE1   [POST]
        //DATA FROM Body { "NAME" : "IT Oracle"}

        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] LIKE1 like)
        {
            await Task.Delay(300);
            like.CREATEAT = System.DateTime.Now;
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(await _genericService.GenericCRUD<string>("INSERT", like));
        }

        //https://localhost:44372/api/LIKE1   [PUT]
        //DATA FROM Body { "ID" : 2,"NAME" : "IT New Oracle"}
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] LIKE1 like)
        {
            await Task.Delay(300);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(await _genericService.GenericCRUD<string>("UPDATE", like));
        }

        //https://localhost:44372/api/LIKE1   [Delete]
        //DATA FROM Body { "ID" : 2}
        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] LIKE1 like)
        {
            await Task.Delay(300);
            var exi = await _genericService.GenericCRUD<LIKE1>("GETBYID", like);
            if (!ModelState.IsValid || exi == null)
            {
                return BadRequest(ModelState);
            }

            return Ok(await _genericService.GenericCRUD<string>("DELETE", like));
        }
    }
}
