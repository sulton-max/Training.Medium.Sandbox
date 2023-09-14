using System.Linq.Expressions;
using Shared.Models.Entities;

namespace EntitiesSection.Services.Interfaces;

public interface IPostViewService
{
    IQueryable<PostView> Get(Expression<Func<PostView, bool>> predicate);

    ValueTask<ICollection<PostView>> GetAsync(IEnumerable<Guid> ids);

    ValueTask<ICollection<PostView>> GetByPostId(Guid id);

    ValueTask<ICollection<PostView>> GetByUserId(Guid id);

    ValueTask<PostView?> GetByIdAsync(Guid id);

    ValueTask<PostView> CreateAsync(Guid postId, Guid userId, bool saveChanges = true);

    ValueTask<PostView> DeleteAsync(Guid id, bool saveChanges = true);
}