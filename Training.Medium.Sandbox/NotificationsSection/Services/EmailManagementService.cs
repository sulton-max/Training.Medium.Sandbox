using System.Diagnostics;
using EntitiesSection.Services.Interfaces;
using NotificationsSection.Models;
using NotificationsSection.Services.Interfaces;
using Shared.Models.Entities;

namespace NotificationsSection.Services;

public class EmailManagementService : IEmailManagementService
{
    private readonly IEmailTemplateService _emailTemplateService;
    private readonly IEmailPlaceholderService _emailPlaceholderService;
    private readonly IEmailMessageService _emailMessageService;
    private readonly IEmailSenderService _emailSenderService;
    private readonly IEmailService _emailService;
    private readonly IUserService _userService;

    public EmailManagementService(
        IEmailTemplateService emailTemplateService,
        IEmailPlaceholderService emailPlaceholderService,
        IEmailMessageService emailMessageService,
        IEmailSenderService emailSenderService,
        IEmailService emailService,
        IUserService userService
    )
    {
        _emailTemplateService = emailTemplateService;
        _emailPlaceholderService = emailPlaceholderService;
        _emailMessageService = emailMessageService;
        _emailSenderService = emailSenderService;
        _emailService = emailService;
        _userService = userService;
    }

    public ValueTask<bool> SendEmailAsync(Guid userId, Guid templateId)
    {
        // var template = await _emailTemplateService.GetByIdAsync(templateId) ?? throw new InvalidOperationException();
        // var placeholders = await _emailPlaceholderService.GetTemplateValues(userId, template);
        //
        // var user = await _userService.GetByIdAsync(userId) ?? throw new InvalidOperationException();
        // var appEmailAddress = "";
        //
        // // Medium
        // // Test
        // // no-reply.medium-test@gmail.com
        //
        // var message = await _emailMessageService.ConvertToMessage(template, placeholders, userId, systemUserId);
        // var result = await _emailSenderService.SendEmailAsync(message);
        // var email = ToEmail(message);
        // email.IsSent = result;
        //
        // await _emailService.CreateAsync(email);

        return new ValueTask<bool>(true);
    }

    public ValueTask<bool> SendEmailAsync(Guid userId, string templateCategory)
    {
        throw new NotImplementedException();
    }

    private Email ToEmail(EmailMessage message)
    {
        return new Email();
    }
}