using NotificationsSection.Models;
using NotificationsSection.Services.Interfaces;
using Shared.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationsSection.Services
{
    public class EmailMessageService : IEmailMessageService
    {
        public ValueTask<EmailMessage> ConvertToMessage(EmailTemplate template, Dictionary<string, string> values)
        {
            throw new NotImplementedException();
        }
    }
}
