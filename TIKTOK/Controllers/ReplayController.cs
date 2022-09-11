using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using TIKTOK.Core.Data;
using TIKTOK.Core.Service;

namespace TIKTOK.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReplayController : ControllerBase
    {
        private readonly IGenericService<REPLAY> _genericService;
        public ReplayController(IGenericService<REPLAY> genericService)
        {
            _genericService = genericService;
        }

        // https://localhost:44372/api/REPLY [Get] 
        // No Data Pass

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            await Task.Delay(300);
            return Ok(await _genericService.GenericCRUD<List<REPLAY>>("GETALL", null));
        }

        // https://localhost:44372/api/REPLY/GetByID [Get] 
        // DATA FROM Body { "ID" : 1}

        [HttpGet("GetByID")]
        public async Task<IActionResult> GetByID([FromBody] REPLAY reply)
        {
            await Task.Delay(300);
            return Ok(await _genericService.GenericCRUD<REPLAY>("GETBYID", reply));
        }


        //https://localhost:44372/api/REPLY   [POST]

        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] REPLAY reply)
        {
            await Task.Delay(300);
            reply.createAt = System.DateTime.Now;
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(await _genericService.GenericCRUD<string>("INSERT", reply));
        }

        //https://localhost:44372/api/REPLY   [PUT]
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] REPLAY reply)
        {
            await Task.Delay(300);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(await _genericService.GenericCRUD<string>("UPDATE", reply));
        }

        //https://localhost:44372/api/REPLY   [Delete]
        //DATA FROM Body { "ID" : 2}
        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] REPLAY reply)
        {
            await Task.Delay(300);
            var exi = await _genericService.GenericCRUD<REPLAY>("GETBYID", reply);
            if (!ModelState.IsValid || exi == null)
            {
                return BadRequest(ModelState);
            }

            return Ok(await _genericService.GenericCRUD<string>("DELETE", reply));
        }

        [HttpPost]
        [Route("uploadFile/{typeFile}")]
        public REPLAY UploadImage(int typeFile)
        {

            try
            {
                var file = Request.Form.Files[0]; // Image

                var fileName = Guid.NewGuid().ToString() + "_" + file.FileName;
                var fullPath = "";
                if (typeFile == 1)
                {
                    //Upload Image
                    fullPath = Path.Combine("C:\\Users\\HP\\OneDrive\\Desktop\\angluarProject\\TikTok\\src\\assets\\images", fileName);
                }
                else if (typeFile == 2)
                {
                    fullPath = Path.Combine("C:\\Users\\HP\\OneDrive\\Desktop\\angluarProject\\TikTok\\src\\assets\\videos", fileName);

                }

                using (var stream = new FileStream(fullPath,
                FileMode.Create))
                {
                    file.CopyTo(stream);
                }
                REPLAY Item = new REPLAY();
                Item.imagePath = fileName;
                return Item;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        } 
    }
    
}

