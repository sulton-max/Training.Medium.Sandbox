using NotificationsSection.Models;
using NotificationsSection.Services.Interfaces;
using Shared.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NotificationsSection.Services
{
    public class EmailMessageService : IEmailMessageService
    {
        public ValueTask<EmailMessage> ConvertToMessage(EmailTemplate template, Dictionary<string, string> values, string sender, string receiver)
        {
            var body = template.Body;
            foreach (var value in values)
            {
                body = body.Replace(value.Key, value.Value);
            }
            var emailMessage = new EmailMessage(template.Subject, body, sender, receiver);
            return ValueTask.FromResult(emailMessage);
        }
    }
}
