using Shared.Models.Entities;
using System.Linq.Expressions;

namespace EntitiesSection.Services.Interfaces;

public interface IPostCommentService
{
    IQueryable<PostComment> Get(Expression<Func<PostComment, bool>> predicate);

    ValueTask<ICollection<PostComment>> GetAsync(IEnumerable<Guid> ids);

    ValueTask<PostComment?> GetByIdAsync(Guid id);

    ValueTask<PostComment> CreateAsync(PostComment postComment, bool saveChanges = true);

    ValueTask<PostComment> UpdateAsync(PostComment postComment, bool saveChanges = true);

    ValueTask<PostComment> DeleteAsync(Guid id, bool saveChanges = true);

    ValueTask<PostComment> DeleteAsync(PostComment postComment, bool saveChanges = true);
}