using MailApi.DTOs;

namespace MailApi.Services.Abstractions
{
    public interface IMailService
    {
        Task SendMail(MailDto mailDto);
    }
}
