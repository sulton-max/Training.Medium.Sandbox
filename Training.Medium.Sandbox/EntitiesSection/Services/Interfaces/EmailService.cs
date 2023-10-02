using System.Linq.Expressions;
using Shared.Models.Entities;

namespace EntitiesSection.Services.Interfaces;

public class EmailService : IEmailService
{
    public IQueryable<Email> Get(Expression<Func<Email, bool>> predicate)
    {
        throw new NotImplementedException();
    }

    public ValueTask<ICollection<Email>> GetAsync(IEnumerable<Guid> ids)
    {
        throw new NotImplementedException();
    }

    public ValueTask<Email?> GetByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public ValueTask<Email> CreateAsync(Email Email, bool saveChanges = true)
    {
        throw new NotImplementedException();
    }

    public ValueTask<Email> UpdateAsync(Email Email, bool saveChanges = true)
    {
        throw new NotImplementedException();
    }

    public ValueTask<Email> DeleteAsync(Guid id, bool saveChanges = true)
    {
        throw new NotImplementedException();
    }

    public ValueTask<Email> DeleteAsync(Email Email, bool saveChanges = true)
    {
        throw new NotImplementedException();
    }
}