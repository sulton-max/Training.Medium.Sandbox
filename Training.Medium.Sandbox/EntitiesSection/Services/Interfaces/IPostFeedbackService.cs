using Shared.Models.Entities;
using System.Linq.Expressions;

namespace EntitiesSection.Services.Interfaces;
public interface IPostFeedbackService
{
    IQueryable<PostFeedback> Get(Expression<Func<PostFeedback, bool>> predicate);

    Task ClapAsync(Guid postId, Guid userId);
}