using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TIKTOK.Core.Dto;
using MailKit.Net.Smtp;
using TIKTOK.Core.Service;
using System.IO;
using MimeKit.Utils;

namespace TIKTOK.Infra.Service
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _configuration;
        [Obsolete]
        private readonly IHostingEnvironment _hostingEnvironment;
        [Obsolete]
        public EmailService(IConfiguration configuration, IHostingEnvironment hostingEnvironment)
        {
            _configuration = configuration;
            _hostingEnvironment = hostingEnvironment;
        }
        public async Task<string> SendEmailWebToUser(SendEmailDto email)
        {
            EmailSmtpDto emailSMTP = GetDataEmailSmtpDto();
            if(email.fullName != null)
            {
                email.message += " <br>Full Name :: <br>" + email.fullName;
                email.message += " <br>Email :: <br>" + email.email;
                email.email = emailSMTP.userName;
                
            }
            MimeMessage message = new MimeMessage();
            BodyBuilder builder = new BodyBuilder();
            MailboxAddress to = new MailboxAddress("user", email.email);
            builder.HtmlBody = email.message;
            message.Body = builder.ToMessageBody();
            message.To.Add(to);
            message.Subject = email.subject;
            return await SendEmail(message);
        }
        public async Task<string> SendEmailRepotToAdmin(SendEmailDto email)
        {
            EmailSmtpDto emailSMTP = GetDataEmailSmtpDto();
            if(email.email == null)
            {
                email.email = emailSMTP.userName;
            }
    
            MimeMessage message = new MimeMessage();
            BodyBuilder builder = new BodyBuilder();
            MailboxAddress from = new MailboxAddress("Web", emailSMTP.userName);
            MailboxAddress to = new MailboxAddress("user", email.email);
            builder.HtmlBody = email.message;

            byte[] fileBytes;

            using (var ms = new MemoryStream())
            {
                email.file.CopyTo(ms);
                fileBytes = ms.ToArray();
            }
            builder.Attachments.Add(email.file.FileName, fileBytes, ContentType.Parse(email.file.ContentType));
            message.Body = builder.ToMessageBody();
            message.From.Add(from);
            message.To.Add(to);
            message.Subject = email.subject;
            
            using (var item = new SmtpClient())
            {
                item.Connect(emailSMTP.host, emailSMTP.port, false);
                item.Authenticate(emailSMTP.userName, emailSMTP.password);
                var x = await item.SendAsync(message);
                item.Disconnect(true);
                return x;

            }
        }
        public async Task<string> SendEmailBlockVideo(SendEmailDto email)
        {
            // email => { subject titleVido  , message = userNAme  ,email=userEmail }

            MimeMessage message = new MimeMessage();
            BodyBuilder builder = new BodyBuilder();
            MailboxAddress to = new MailboxAddress("user", email.email);
            builder = GetTemplateEmail("BlockVideoTemp.html");
            builder.HtmlBody = builder.HtmlBody.Replace("-%%-USERNAME-%%-", email.message);
            builder.HtmlBody = builder.HtmlBody.Replace("-%%-TITLE-%%-", email.subject);
            

            message.Body = builder.ToMessageBody();
            message.To.Add(to);
            message.Subject = "Block Video From TikTok";
            return await SendEmail(message);
        }
        public async Task<string> SendEmailBlockUser(SendEmailDto email)
        {
            // email => { message = userNAme  ,email=userEmail }

            MimeMessage message = new MimeMessage();
            BodyBuilder builder = new BodyBuilder();
            MailboxAddress to = new MailboxAddress("user", email.email);
            builder = GetTemplateEmail("BlockUserTemp.html");

            builder.HtmlBody = builder.HtmlBody.Replace("-%%-USERNAME-%%-", email.message);
            builder.HtmlBody = builder.HtmlBody.Replace("-%%-TITLE-%%-", " ");

            message.Body = builder.ToMessageBody();
            message.To.Add(to);
            message.Subject = "Block User From TikTok";
            return await SendEmail(message);
        }
        public async Task<string> SendEmailConfirmEmail(SendEmailDto email)
        {
            EmailSmtpDto emailSMTP = GetDataEmailSmtpDto();
            //message => userNAme     email = eamilUser   subject Token 
            MimeMessage message = new MimeMessage();
            BodyBuilder builder = new BodyBuilder();
            MailboxAddress to = new MailboxAddress("user", email.email);
            // To Get template 
            builder = GetTemplateEmail("ConfiremEmail.html");


            builder.HtmlBody = builder.HtmlBody.Replace("-%%-USERNAME-%%-", email.message);
            var herf = string.Format(@"<a href='http://localhost:4200/auth/ConfiremEmail/{0}' style='background-color: #000;color: rgba(254, 44, 85, 1);border-radius: 8px;padding: 20px 30px;font-weight: bold;' > Confirm Email </a>", email.subject);
            builder.HtmlBody = builder.HtmlBody.Replace("-%%-hrefHere-%%-", herf);

            message.Body = builder.ToMessageBody();
            message.To.Add(to);
            message.Subject = "Confirm Email From TikTok";

            return await SendEmail(message);
        }
        public async Task<string> SendForgetPassWord(SendEmailDto email)
        {
            //message => userNAme     email = eamilUser   subject Token 
            MimeMessage message = new MimeMessage();
            BodyBuilder builder = new BodyBuilder();
            MailboxAddress to = new MailboxAddress("user", email.email);
            builder = GetTemplateEmail("ForgetPassWord.html");

            var herf = string.Format(@"<a href='http://localhost:4200/auth/ForgetPassword/{0}' style='background-color: #000;color: rgba(254, 44, 85, 1);border-radius: 8px;padding: 20px 30px;font-weight: bold;' > Forget Password </a>", email.subject);
            builder.HtmlBody = builder.HtmlBody.Replace("-%%-hrefHere-%%-", herf);
            

            message.Body = builder.ToMessageBody();
            message.To.Add(to);
            message.Subject = "Forget Password From TikTok !";
            return await SendEmail(message);
        }
        private EmailSmtpDto GetDataEmailSmtpDto()
        {
            EmailSmtpDto EmailSmtpDto = new EmailSmtpDto();
            EmailSmtpDto.host = _configuration["Smtp:Host"];
            EmailSmtpDto.port = Int32.Parse(_configuration["Smtp:Port"]);
            EmailSmtpDto.userName = _configuration["Smtp:Username"];
            EmailSmtpDto.password = _configuration["Smtp:Password"];
            return EmailSmtpDto;
        }
        private async Task<string> SendEmail(MimeMessage message)
        {
            EmailSmtpDto emailSMTP = GetDataEmailSmtpDto();
            MailboxAddress from = new MailboxAddress("Tiktok", emailSMTP.userName);
            message.From.Add(from);
            using (var item = new SmtpClient())
            {
                item.Connect(emailSMTP.host, emailSMTP.port, false);
                item.Authenticate(emailSMTP.userName, emailSMTP.password);
                var send = await item.SendAsync(message);
                item.Disconnect(true);
                return send;

            }
        }
        private BodyBuilder GetTemplateEmail(string nameTemp )
        {
            BodyBuilder builder = new BodyBuilder();
            builder.HtmlBody = File.ReadAllText(@"C:\Users\HP\OneDrive\Desktop\angluarProject\TikTok\src\assets\htmlemail\"+ nameTemp);

            //Emend Logo Image In Email
            var image = builder.LinkedResources.Add(@"C:\Users\HP\OneDrive\Desktop\angluarProject\TikTok\src\assets\htmlemail\images\LogoTiktok.png");
            image.ContentId = MimeUtils.GenerateMessageId();
            var imageLogoTag = string.Format(@"<img src=""cid:{0}"" align='center' class='icon' height='15' width='500' style='display: block; height: auto; margin: 0 auto; border: 0; '>", image.ContentId);
            builder.HtmlBody = builder.HtmlBody.Replace("-%%-ImageLogo-%%-", imageLogoTag);

            //Emend Show Image In Email
            var image1 = builder.LinkedResources.Add(@"C:\Users\HP\OneDrive\Desktop\angluarProject\TikTok\src\assets\htmlemail\images\TiktokimageShow.jpg");
            image1.ContentId = MimeUtils.GenerateMessageId();
            var imageShow = string.Format(@"<img src=""cid:{0}"" class='fullMobileWidth' style = 'display: block;height: auto;border: 0;width: 100%;max-width: 100%;' title = 'Social profile' width = '442' > ", image1.ContentId);
            builder.HtmlBody = builder.HtmlBody.Replace("-%%-ImageShow-%%-", imageShow);

            return builder; 
        }
    }
}
