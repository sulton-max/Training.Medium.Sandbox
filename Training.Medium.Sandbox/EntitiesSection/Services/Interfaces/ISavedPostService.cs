using System.Linq.Expressions;
using Shared.Models.Entities;

namespace EntitiesSection.Services.Interfaces;

public interface ISavedPostService
{
    IQueryable<SavedPost> Get(Expression<Func<User, bool>> predicate);

    ValueTask<ICollection<SavedPost>> GetByUserIdAsync(IEnumerable<Guid> ids);

    ValueTask<SavedPost?> GetByIdAsync(Guid id);

    ValueTask<SavedPost> AddToSaveAsync(User user, bool saveChanges = true);

    ValueTask<SavedPost> DeleteSaveAsync(User user, bool saveChanges = true);
}