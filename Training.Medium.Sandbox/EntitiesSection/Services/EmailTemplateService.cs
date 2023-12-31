﻿using EntitiesSection.Services.Interfaces;
using Microsoft.VisualBasic;
using Shared.DataAccess.Contexts;
using Shared.Models.Entities;
using System.Linq.Expressions;

namespace EntitiesSection.Services;

public class EmailTemplateService : IEmailTemplateService
{
    private readonly IDataContext _appDateContext;
   // private readonly IEmailTemplateService _emailTemplateService;
    public EmailTemplateService(IDataContext appDateContext ) //IEmailTemplateService emailTemplateService
    {
        _appDateContext = appDateContext;
        //_emailTemplateService = emailTemplateService;

    }
    public async ValueTask<EmailTemplate> CreateAsync(EmailTemplate emailTemplate, bool saveChanges = true)
    {
       await _appDateContext.EmailTemplates.AddAsync(emailTemplate);
        if(saveChanges)
            await _appDateContext.SaveChangesAsync();
        return emailTemplate;
    }
    
    public IQueryable<EmailTemplate> Get(Expression<Func<EmailTemplate, bool>> expression)
    {
       return _appDateContext.EmailTemplates.Where(expression.Compile()).AsQueryable();
    }
    
    public ValueTask<EmailTemplate?> GetByIdAsync(Guid id)
    {
        var emailTemplate = _appDateContext.EmailTemplates.FirstOrDefault(emailTemplate => emailTemplate.Id == id);
        return new ValueTask<EmailTemplate?>(emailTemplate);
    }
    
    public ValueTask<ICollection<EmailTemplate>> GetAsync(IEnumerable<Guid> ids)
    {
        var emailTemlates = _appDateContext.EmailTemplates.Where(emailtemplate => ids.Contains(emailtemplate.Id));
        return new  ValueTask<ICollection<EmailTemplate>>(emailTemlates.ToList());
    }
    
    public async ValueTask<EmailTemplate> UpdateAsync(EmailTemplate emailTemplate, bool saveChanges = true)
    {
        var foundEmailTemplate = _appDateContext.EmailTemplates.FirstOrDefault(searched => searched.Id == emailTemplate.Id);
        if (foundEmailTemplate is null)
            throw new InvalidOperationException("EmailTemplate not found");
        foundEmailTemplate.Subject = emailTemplate.Subject;
        foundEmailTemplate.Body = emailTemplate.Body; 
        

        await _appDateContext.SaveChangesAsync();
        return foundEmailTemplate;
    }
    
    public async ValueTask<EmailTemplate> DeleteAsync(Guid id, bool saveChanges = true)
    {
        var foundEmailTemplate = await GetByIdAsync(id);
        if (foundEmailTemplate is null)
            throw new InvalidOperationException("You searched emailTemplate not found");
        foundEmailTemplate.IsDeleted = true;
        await _appDateContext.SaveChangesAsync();
        return foundEmailTemplate;
    }

    public async ValueTask<EmailTemplate> DeleteAsync(EmailTemplate emailTemplate, bool saveChanges = true)
    {
        var foundEmailTemplate = await GetByIdAsync(emailTemplate.Id);
        if (foundEmailTemplate is null)
            throw new InvalidOperationException("You searched emailTemplate not found");
        
        await _appDateContext.SaveChangesAsync();
        return foundEmailTemplate;
    }
}
