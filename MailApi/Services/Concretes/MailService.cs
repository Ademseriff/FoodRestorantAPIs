using MailApi.Services.Abstractions;
using System.Net.Mail;
using System.Net;
using MailApi.DTOs;

namespace MailApi.Services.Concretes
{
    public class MailService : IMailService
    {
        public async Task SendMail(MailDto mailDto)
        {
            try
            {

                string FromMail = "durholding@gmail.com";
                string FromPassword = "uvxu kfke dozf jisa";

                MailMessage message = new MailMessage();
                message.From = new MailAddress(FromMail);
                message.Subject = mailDto.Subject;

                message.To.Add(new MailAddress(mailDto.Reciver));
                message.Body = mailDto.Body;
                var smtpClient = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587,
                    Credentials = new NetworkCredential(FromMail, FromPassword),
                    EnableSsl = true
                };
                await smtpClient.SendMailAsync(message);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"E-posta gönderme hatası: {ex.Message}");
            }

        }
    }
}
