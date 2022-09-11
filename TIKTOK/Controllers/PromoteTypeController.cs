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
    public class PromoteTypeController : ControllerBase
    {
        private readonly IGenericService<PROMOTETYPE> _genericService;
        public PromoteTypeController(IGenericService<PROMOTETYPE> genericService)
        {
            _genericService = genericService;
        }

        // https://localhost:44372/api/PROMOTETYPE [Get] 
        // No Data Pass

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            await Task.Delay(300);
            return Ok(await _genericService.GenericCRUD<List<PROMOTETYPE>>("GETALL", null));
        }

        // https://localhost:44372/api/PROMOTETYPE/GetByID [Get] 
        // DATA FROM Body { "ID" : 1}

        [HttpGet("GetByID")]
        public async Task<IActionResult> GetByID([FromBody] PROMOTETYPE ptype)
        {
            await Task.Delay(300);
            return Ok(await _genericService.GenericCRUD<PROMOTETYPE>("GETBYID", ptype));
        }


        //https://localhost:44372/api/PROMOTETYPE   [POST]
        //DATA FROM Body { "NAME" : "IT Oracle"}

        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] PROMOTETYPE ptype)
        {
            await Task.Delay(300);
            var exi = await _genericService.GenericCRUD<PROMOTETYPE>("GETBYNAME", ptype);
            if (!ModelState.IsValid || exi != null)
            {
                return BadRequest(ModelState);
            }

            return Ok(await _genericService.GenericCRUD<string>("INSERT", ptype));
        }

        //https://localhost:44372/api/PROMOTETYPE   [PUT]
        //DATA FROM Body { "ID" : 2,"NAME" : "IT New Oracle"}
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] PROMOTETYPE ptype)
        {
            await Task.Delay(300);
            if (!ModelState.IsValid )
            {
                return BadRequest(ModelState);
            }

            return Ok(await _genericService.GenericCRUD<string>("UPDATE", ptype));
        }

        //https://localhost:44372/api/PROMOTETYPE   [Delete]
        //DATA FROM Body { "ID" : 2}
        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] PROMOTETYPE ptype)
        {
            await Task.Delay(300);
            var exi = await _genericService.GenericCRUD<PROMOTETYPE>("GETBYID", ptype);
            if (!ModelState.IsValid || exi == null)
            {
                return BadRequest(ModelState);
            }

            return Ok(await _genericService.GenericCRUD<string>("DELETE", ptype));
        }
    }
}
