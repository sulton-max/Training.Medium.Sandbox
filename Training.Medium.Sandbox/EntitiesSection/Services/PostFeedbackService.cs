using Bogus;
using EntitiesSection.Services.Interfaces;
using Shared.DataAccess.Contexts;
using Shared.Models.Entities;
namespace EntitiesSection.Services;
public class PostFeedbackService : IPostFeedbackService
{
    private readonly AppFileContext _appDateContext;

    public PostFeedbackService(AppFileContext appFileContext)
        => _appDateContext = appFileContext;
    public async Task ClapAsync(Guid postId, Guid userId)
    {
        var IsExistInData = _appDateContext.PostFeedbacks
            .FirstOrDefault(feedback => feedback.PostId == postId && feedback.UserId == userId);
        
        if(IsExistInData == null)
        {
            await _appDateContext.PostFeedbacks.AddAsync(new PostFeedback(userId, postId, 1));
            await _appDateContext.PostFeedbacks.SaveChangesAsync();
            return;
        }

        IsExistInData.UserClaps += 1;
        await _appDateContext.PostFeedbacks.SaveChangesAsync();
        return;
    }
}
