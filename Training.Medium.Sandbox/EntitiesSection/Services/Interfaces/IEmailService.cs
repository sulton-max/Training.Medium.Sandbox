using System.Linq.Expressions;
using Shared.Models.Entities;

namespace EntitiesSection.Services.Interfaces;

public interface IEmailService
{
    IQueryable<Email> Get(Expression<Func<Email, bool>> predicate);

    ValueTask<ICollection<Email>> GetAsync(IEnumerable<Guid> ids);

    ValueTask<Email?> GetByIdAsync(Guid id);

    ValueTask<Email> CreateAsync(Email Email, bool saveChanges = true);

    ValueTask<Email> UpdateAsync(Email Email, bool saveChanges = true);

    ValueTask<Email> DeleteAsync(Guid id, bool saveChanges = true);

    ValueTask<Email> DeleteAsync(Email Email, bool saveChanges = true);
}