using NotificationsSection.Models;
using Shared.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationsSection.Services.Interfaces
{
    public interface IEmailMessageService
    {
        ValueTask<EmailMessage> ConvertToMessage(EmailTemplate template, Dictionary<string, string> values);       
    }
}
