using NotificationsSection.Models;

namespace NotificationsSection.Services.Interfaces;

public interface IEmailSenderService
{
    ValueTask<bool> SendEmailAsync(EmailMessage emailMessage);
}