using MailApi.DTOs;
using MailApi.Services.Abstractions;
using MassTransit;
using Shared.Events;

namespace MailApi.Consumers
{
    public class MailSentEventConsumer : IConsumer<MailSentEvent>
    {
        private readonly IMailService mailService;

        public MailSentEventConsumer(IMailService mailService)
        {
            this.mailService = mailService;
        }

        public async Task Consume(ConsumeContext<MailSentEvent> context)
        {
            MailDto mailDto = new MailDto();
            mailDto.Subject = "Yemek Şiparişiniz Hakkında";
            mailDto.Reciver = context.Message.EMail;
            if (context.Message.State == Shared.Enums.State.pending)
            {
                mailDto.Body = "Siparişiniz alınmıştır.";
                await mailService.SendMail(mailDto);
            }

            else if (context.Message.State == Shared.Enums.State.successful)
            {
                mailDto.Body = $"{context.Message.OrderId}: nolu Siparişiniz tamamlanmıştır Bizi tercih ettiğiniz için teşekkür ederiz.";
                await mailService.SendMail(mailDto);
            }
            else if (context.Message.State == Shared.Enums.State.failed)
            {
                mailDto.Body = $"{context.Message.OrderId}: nolu Siparişiniz iptal edilmiştir. Allaha emanetsiniz";
                await mailService.SendMail(mailDto);
            }

        }
    }
}
