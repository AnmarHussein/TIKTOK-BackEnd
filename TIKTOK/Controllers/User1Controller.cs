using Microsoft.AspNetCore.Authorization;
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
    public class User1Controller : ControllerBase
    {
        private readonly IGenericService<USER1> _genericService;
        public User1Controller(IGenericService<USER1> genericService)
        {
            _genericService = genericService;
        }

        // https://localhost:44372/api/User1 [Get] 
        // No Data Pass

        [HttpGet]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> GetAll()
        {
            await Task.Delay(300);
            return Ok(await _genericService.GenericCRUD<List<USER1>>("GETALL", null));
        }

        // https://localhost:44372/api/User1/GetByID [Get] 
        // DATA FROM Body { "ID" : 1}

        [HttpPost("GetByID")]
        public async Task<IActionResult> GetByID([FromBody] USER1 user)
        {
            await Task.Delay(300);
            return Ok(await _genericService.GenericCRUD<USER1>("GETBYID", user));
        }


        //https://localhost:44372/api/User1   [POST]
        //DATA FROM Body { data in object USER1 => with Out ID}

        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] USER1 user)
        {
            await Task.Delay(300);
            user.roleId = 2;
            user.imagePath = (user.imagePath != null) ? user.imagePath : "4d6ad52b-220a-4f99-8605-1342bea9c15e_4.PNG";
            var exi = await _genericService.GenericCRUD<USER1>("GETBYNAME", user);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if(exi != null)
            {
                return Ok("The User Name Is Exist!!");
            }

            return Ok(await _genericService.GenericCRUD<string>("INSERT", user));
        }

        //https://localhost:44372/api/USER1   [PUT]
        //DATA FROM Body { data in object USER1 => with ID}
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] USER1 user)
        {
            await Task.Delay(300);
            if (!ModelState.IsValid )
            {
                return BadRequest(ModelState);
            }

            return Ok(await _genericService.GenericCRUD<string>("UPDATE", user));
        }

        //https://localhost:44372/api/USER1   [Delete]
        //DATA FROM Body { "ID" : 2 }
        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] USER1 user)
        {
            await Task.Delay(300);
            var exi = await _genericService.GenericCRUD<USER1>("GETBYID", user);
            if (!ModelState.IsValid || exi == null)
            {
                return BadRequest(ModelState);
            }

            return Ok(await _genericService.GenericCRUD<string>("DELETE", user));
        }

        [HttpPost]
        [Route("uploadImage")]
        public USER1 UploadImage()
        {
            try
            {
                var file = Request.Form.Files[0]; // Image

                var fileName = Guid.NewGuid().ToString() + "_"
                + file.FileName;// jbxhvxvx_img.jpg, shbbxhsb_img.jpg
                var fullPath = Path.Combine("C:\\Users\\HP\\OneDrive\\Desktop\\angluarProject\\TikTok\\src\\assets\\images", fileName);

                using (var stream = new FileStream(fullPath,
                FileMode.Create))
                {
                    file.CopyTo(stream);
                }
                USER1 Item = new USER1();
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
