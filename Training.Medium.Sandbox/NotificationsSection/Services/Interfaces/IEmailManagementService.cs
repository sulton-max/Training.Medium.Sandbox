namespace NotificationsSection.Services.Interfaces;

public interface IEmailManagementService
{
    ValueTask<bool> SendEmailAsync(Guid userId, Guid templateId);
    ValueTask<bool> SendEmailAsync(Guid userId, string templateCategory);
}