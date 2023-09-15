using System.Linq.Expressions;
using EntitiesSection.Services.Interfaces;
using Shared.DataAccess.Contexts;
using Shared.Models.Entities;

namespace EntitiesSection;

public class PostViewService : IPostViewService
{
    private readonly IDataContext _appDataContext;

    public PostViewService(IDataContext appDataContext)
    {
        _appDataContext = appDataContext;
    }

    public IQueryable<PostView> Get(Expression<Func<PostView, bool>> predicate)
    {
        return _appDataContext.PostViews.Where(predicate.Compile()).AsQueryable();
    }

    public ValueTask<ICollection<PostView>> GetAsync(IEnumerable<Guid> ids)
    {
        var postViews = _appDataContext.PostViews.Where(postView => ids.Contains(postView.Id)).ToList();
        return new ValueTask<ICollection<PostView>>(postViews);
    }

    public ValueTask<ICollection<PostView>> GetByPostId(Guid id)
    {
        var postViews = _appDataContext.PostViews.Where(postView => postView.PostId == id).ToList();
        return new ValueTask<ICollection<PostView>>(postViews);
    }

    public ValueTask<ICollection<PostView>> GetByUserId(Guid id)
    {
        var postViews = _appDataContext.PostViews.Where(postView => postView.UserId == id).ToList();
        return new ValueTask<ICollection<PostView>>(postViews);
    }

    public ValueTask<PostView?> GetByIdAsync(Guid id)
    {
        var postView = _appDataContext.PostViews.FirstOrDefault(postView => postView.Id == id);
        return new ValueTask<PostView?>(postView);
    }

    public async ValueTask<PostView> CreateAsync(Guid postId, Guid userId, bool saveChanges = true)
    {
        await _appDataContext.PostViews.AddAsync(new PostView(postId, userId));

        if (saveChanges)
            await _appDataContext.SaveChangesAsync();

        return new PostView(postId, userId);
    }

    public async ValueTask<PostView> DeleteAsync(Guid id, bool saveChanges = true)
    {
        var foundPostView = _appDataContext.PostViews.FirstOrDefault(postView => postView.Id == id);

        if (foundPostView is null)
            throw new InvalidOperationException("PostView not found");

        await _appDataContext.PostViews.RemoveAsync(foundPostView);

        if (saveChanges)
            await _appDataContext.SaveChangesAsync();

        return foundPostView;
    }
}