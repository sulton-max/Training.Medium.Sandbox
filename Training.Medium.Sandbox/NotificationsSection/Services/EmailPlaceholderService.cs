using System.Data;
using EntitiesSection.Services.Interfaces;
using NotificationsSection.Services.Interfaces;
using Shared.Models.Entities;

namespace NotificationsSection.Services
{
    public class EmailPlaceholderService : IEmailPlaceholderService
    {
        private readonly IUserService _userService;

        public EmailPlaceholderService(IUserService userService)
        {
            _userService = userService;
        }

        public async ValueTask<(EmailTemplate, Dictionary<string, string>)> GetTemplateValues(Guid userId, EmailTemplate template)
        {
            // regex
            // index

            // template.Body.

            // get placeholders into string []  - {{X}}
            // FullName

            var placeholders = new List<string>();

            var user = await _userService.GetByIdAsync(userId) ?? throw new ArgumentException();

            var result = placeholders.Select(placeholder =>
            {
                var value = placeholder switch
                {
                    "{{FullName}}" => string.Join(user.FirstName, " ", user.LastName),
                    _ => throw new EvaluateException("Invalid placeholder")
                };

                return new KeyValuePair<string, string>(placeholder, value);
            });

            var values = new Dictionary<string, string>(result);
            return (template, values);
        }
    }
}