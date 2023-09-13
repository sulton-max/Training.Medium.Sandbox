using System.Linq.Expressions;
using Shared.Models.Common;

namespace Shared.Models.Entities;

public class SavedPost : SoftDeletedEntity
{
    IQueryable<User> Get(Expression<Func<User, bool>> predicate);

    ValueTask<ICollection<User>> GetAsync(IEnumerable<Guid> ids);

    ValueTask<User?> GetByIdAsync(Guid id);

    ValueTask<User> CreateAsync(User user, bool saveChanges = true);

    ValueTask<User> UpdateAsync(User user, bool saveChanges = true);

    ValueTask<User> DeleteAsync(Guid id, bool saveChanges = true);

    ValueTask<User> DeleteAsync(User user, bool saveChanges = true);
}