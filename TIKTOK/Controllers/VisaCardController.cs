using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TIKTOK.Core.Data;
using TIKTOK.Core.Service;

namespace TIKTOK.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VisaCardController : ControllerBase
    {
        private readonly IGenericService<VISACARD> _genericService;
        public VisaCardController(IGenericService<VISACARD> genericService)
        {
            _genericService = genericService;
        }

        // https://localhost:44372/api/VISACARD [Get] 
        // No Data Pass

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            await Task.Delay(300);
            return Ok(await _genericService.GenericCRUD<List<VISACARD>>("GETALL", null));
        }

        // https://localhost:44372/api/VISACARD/GetByID [Get] 
        // DATA FROM Body { "ID" : 1}

        [HttpGet("GetByID")]
        public async Task<IActionResult> GetByID([FromBody] VISACARD visa)
        {
            await Task.Delay(300);
            return Ok(await _genericService.GenericCRUD<VISACARD>("GETBYID", visa));
        }


        //https://localhost:44372/api/VISACARD   [POST]
        //DATA FROM Body { data in object VISACARD => with Out ID}

        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] VISACARD visa)
        {
            await Task.Delay(300);
            var exi = await _genericService.GenericCRUD<VISACARD>("GETBYCARDNUMBER", visa);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (exi != null)
            {
                return Ok("The User Name Is Exist!!");
            }

            return Ok(await _genericService.GenericCRUD<string>("INSERT", visa));
        }

        //https://localhost:44372/api/VISACARD   [PUT]
        //DATA FROM Body { data in object VISACARD => with ID}
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] VISACARD visa)
        {
            await Task.Delay(300);
            if (!ModelState.IsValid )
            {
                return BadRequest(ModelState);
            }

            return Ok(await _genericService.GenericCRUD<string>("UPDATE", visa));
        }

        //https://localhost:44372/api/VISACARD   [Delete]
        //DATA FROM Body { "ID" : 2 }
        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] VISACARD visa)
        {
            await Task.Delay(300);
            var exi = await _genericService.GenericCRUD<VISACARD>("GETBYID", visa);
            if (!ModelState.IsValid || exi == null)
            {
                return BadRequest(ModelState);
            }

            return Ok(await _genericService.GenericCRUD<string>("DELETE", visa));
        }
    }
}
