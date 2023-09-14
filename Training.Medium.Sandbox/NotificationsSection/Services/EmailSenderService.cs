using NotificationsSection.Models;
using NotificationsSection.Services.Interfaces;

namespace NotificationsSection.Services;

public class EmailSenderService : IEmailSenderService
{
    public ValueTask<bool> SendEmailAsync(EmailMessage emailMessage)
    {
        throw new NotImplementedException();
    }
}