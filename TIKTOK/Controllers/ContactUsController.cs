using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using TIKTOK.Core.Data;
using TIKTOK.Core.Dto;
using TIKTOK.Core.Service;

namespace TIKTOK.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactUsController : ControllerBase
    {
        private readonly IContactUsService _contactUs;
        private readonly IEmailService _emailService;
        public ContactUsController(IContactUsService contactUs, IEmailService emailService)
        {
            _contactUs = contactUs;
            _emailService = emailService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            Task.Delay(1000).Wait();
            return Ok(await _contactUs.GetAll());
        }
        [HttpGet("InboxStatstic")]
        public async Task<IActionResult> InboxStatstic()
        {
            Task.Delay(1000).Wait();
            var res = await _contactUs.GetAll();
            var countInbox1 = res.Where(x=>x.deleteAt==null).Count();
            var countImportant1 = res.Where(x=>x.important == 1 && x.deleteAt == null).Count();
            return Ok(new { countInbox=countInbox1 , countImportant=countImportant1 });
        }


        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] ContactUs contact)
        {
            Task.Delay(1000).Wait();
            SendEmailDto sendEmai = new SendEmailDto();
            sendEmai.subject = contact.subject;
            sendEmai.email = contact.email;
            sendEmai.fullName = contact.fullName;
            sendEmai.message = contact.message;
            await _emailService.SendEmailWebToUser(sendEmai);
            contact.createAt = System.DateTime.Now;
            return Ok(await _contactUs.Insert(contact));
        }
        [HttpPut("important")]
        public async Task<IActionResult> Important([FromBody] ContactUs contact)
        {
            Task.Delay(1000).Wait();
            return Ok(await _contactUs.Important(contact));
        }
        [HttpPut("Trash")]
        public async Task<IActionResult> Trash([FromBody] ContactUs contact)
        {
            Task.Delay(1000).Wait();
            return Ok(await _contactUs.Trash(contact));
        }

        [HttpPut("TrashRemove")]
        public async Task<IActionResult> TrashRemove([FromBody] ContactUs contact)
        {
            Task.Delay(1000).Wait();
            return Ok(await _contactUs.TrashRemove(contact));
        }

        [HttpPut("ReadEmail")]
        public async Task<IActionResult> ReadEmail([FromBody] ContactUs contact)
        {
            Task.Delay(1000).Wait();
            return Ok(await _contactUs.ReadEmail(contact));
        }

        [HttpPost("GetById")]
        public async Task<IActionResult> GetById([FromBody] ContactUs contact)
        {
            Task.Delay(1000).Wait();
            return Ok(await _contactUs.GetById(contact));
        }
        [HttpPost("SendEmailWebToUser")]
        public async Task<IActionResult> SendEmailWebToUser([FromBody] SendEmailDto email)
        {
            Task.Delay(1000).Wait();
            return Ok(await _emailService.SendEmailWebToUser(email));
        }

        [HttpPost("SendEmailPdf/{typeSend}")]
        public async Task<IActionResult> SendEmailPdf(int typeSend)
        {
            var file = Request.Form.Files[0];
            
            SendEmailDto email = new SendEmailDto();
            email.file = file;
            var email2 = Request.Form.Where(x => x.Key == "model").Select(x => x.Value);
            email.email = email2.First();
            if (typeSend == 1)
            {
                email.subject = "Report Of pdf  Profit Or Losess";
                email.message = "The Reports Contain  1- All Promotion And Count Seales And Target ";
            }
            else if(typeSend == 2 && email.email != null)
            {
                email.subject = "Invoce To Promote Videos";
                email.message = "The Reports Contain Ivoice Promote Video ";
            }
            Task.Delay(1000).Wait();
            return Ok(await _emailService.SendEmailRepotToAdmin(email));
        }
    }
}
