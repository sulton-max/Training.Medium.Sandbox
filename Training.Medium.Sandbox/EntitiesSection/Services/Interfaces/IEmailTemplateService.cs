using Shared.Models.Entities;
using System.Linq.Expressions;

namespace EntitiesSection.Services.Interfaces;

public interface IEmailTemplateService
{
    IQueryable<EmailTemplate> Get(Expression<Func<EmailTemplate, bool>> expression);
    ValueTask<ICollection<EmailTemplate>> GetAsync(IEnumerable<Guid> ids);
    ValueTask<EmailTemplate?> GetByIdAsync(Guid id);
    ValueTask<EmailTemplate> CreateAsync(EmailTemplate emailTemplate,bool saveChanges = true);
    ValueTask<EmailTemplate> UpdateAsync(EmailTemplate emailTemplate,bool saveChanges = true);
    ValueTask<EmailTemplate> DeleteAsync(Guid id,bool saveChanges = true);
    ValueTask<EmailTemplate> DeleteAsync(EmailTemplate emailTemplate,bool saveChanges = true);
}
