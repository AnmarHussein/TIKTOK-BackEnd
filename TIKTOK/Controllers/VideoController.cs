using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using TIKTOK.Core.Data;
using TIKTOK.Core.Dto;
using TIKTOK.Core.Service;

namespace TIKTOK.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideoController : ControllerBase
    {
        private readonly IGenericService<VIDEO> _genericService;
        public VideoController(IGenericService<VIDEO> genericService)
        {
            _genericService = genericService;
        }

        // https://localhost:44372/api/VIDEO [Get] 
        // No Data Pass

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAll()
        {
            await Task.Delay(300);
            return Ok(await _genericService.GenericCRUD<List<VIDEO>>("GETALL", null));
        }

        // https://localhost:44372/api/VIDEO/GetByID [Get] 
        // DATA FROM Body { "ID" : 1}

        [HttpGet("GetByID")]
        public async Task<IActionResult> GetByID([FromBody] VIDEO video)
        {
            await Task.Delay(300);
            return Ok(await _genericService.GenericCRUD<VIDEO>("GETBYID", video));
        }


        //https://localhost:44372/api/VIDEO   [POST]
        //DATA FROM Body { "NAME" : "IT Oracle"}

        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] VIDEO video)
        {
            await Task.Delay(300);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            video.createAt = DateTime.Now;
            return Ok(await _genericService.GenericCRUD<string>("INSERT", video));
        }

        //https://localhost:44372/api/VIDEO   [PUT]
        //DATA FROM Body { "ID" : 2,"NAME" : "IT New Oracle"}
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] VIDEO video)
        {
            await Task.Delay(300);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(await _genericService.GenericCRUD<string>("UPDATE", video));
        }

        //https://localhost:44372/api/VIDEO   [Delete]
        //DATA FROM Body { "ID" : 2}
        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] VIDEO video)
        {
            await Task.Delay(300);
            var exi = await _genericService.GenericCRUD<VIDEO>("GETBYID", video);
            if (!ModelState.IsValid || exi == null)
            {
                return BadRequest(ModelState);
            }

            return Ok(await _genericService.GenericCRUD<string>("DELETE", video));
        }

        [HttpPost]
        [Route("uploadFile/{typeFile}")]
        public VIDEO UploadImage(int typeFile)
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
                VIDEO Item = new VIDEO();
                Item.posterPath = fileName;
                return Item;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
