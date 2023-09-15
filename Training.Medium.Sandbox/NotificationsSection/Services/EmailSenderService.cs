using NotificationsSection.Models;
using NotificationsSection.Services.Interfaces;
using System.Net;
using System.Net.Mail;

namespace NotificationsSection.Services;

public class EmailSenderService : IEmailSenderService
{
    public async ValueTask<bool> SendEmailAsync(EmailMessage emailMessage)
    {
        var result = false;
        try
        {

            using (var smtp = new SmtpClient("smtp.gmail.com", 587))
            {
                smtp.Credentials = new NetworkCredential("sultonbek.rakhimov.recovery@gmail.com", "szabguksrhwsbtie");
                smtp.EnableSsl = true;

                var mail = new MailMessage(emailMessage.SenderAddress, emailMessage.ReceiverAddress);
                mail.Subject = emailMessage.Subject;
                mail.Body = emailMessage.Body;

                await smtp.SendMailAsync(mail);
            }

            emailMessage.IsSent = true;
            emailMessage.SentDate = DateTime.UtcNow;
            result = true;
        }
        catch (Exception ex)
        {
            emailMessage.IsSent = false;
            emailMessage.SentDate = DateTime.UtcNow;
            result = false;
            
        }

        return result;
    }
}