using Shared.Models.Entities;

namespace NotificationsSection.Services.Interfaces
{
    public interface IEmailPlaceholderService
    {
        ValueTask<Dictionary<string, string>> GetTemplateValues(Guid userId, EmailTemplate template);
    }
}