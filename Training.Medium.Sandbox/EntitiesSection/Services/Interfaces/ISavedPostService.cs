using System.Linq.Expressions;
using Shared.Models.Entities;

namespace EntitiesSection.Services.Interfaces;

public interface ISavedPostService
{
    IQueryable<SavedPost> Get(Expression<Func<SavedPost, bool>> predicate);//change User to SavedPost

    ValueTask<ICollection<SavedPost>> GetByUserIdAsync(IEnumerable<Guid> ids);

    ValueTask<SavedPost?> GetByIdAsync(Guid id);

    ValueTask<SavedPost> AddToSaveAsync(User user, bool saveChanges = true);

    ValueTask<SavedPost> DeleteSaveAsync(User user, bool saveChanges = true);
}