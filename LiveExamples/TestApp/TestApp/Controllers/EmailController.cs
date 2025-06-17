using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;
using System.Net;

namespace TestApp.Controllers
{
    public class EmailController : Controller
    {
        public IActionResult SendEmail()
        {
            SendEmail("recipient@gmail.com", 
                "Test Email", 
                "Hello, this is a test email with an attachment.", 
                @"D:\\ESSPL\\.Net\\SampleApplication\\DotNetTraining\\LiveExamples\\TestApp\\TestApp\\wwwroot\\uploads\\SampleData.xlsx");
            return Ok("Email sent successfully!");
        }

        private void SendEmail(string toEmail, string subject, string body, string attachmentPath)
        {
            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential("your-email@gmail.com", "your-password"),
                EnableSsl = true
            };

            var mailMessage = new MailMessage
            {
                From = new MailAddress("your-email@gmail.com"),
                Subject = subject,
                Body = body,
                IsBodyHtml = true,
            };

            mailMessage.To.Add(toEmail);

            if (!string.IsNullOrEmpty(attachmentPath))
            {
                mailMessage.Attachments.Add(new Attachment(attachmentPath));
            }

            smtpClient.Send(mailMessage);
        }
    }
}
