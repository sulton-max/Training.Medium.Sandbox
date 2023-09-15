namespace EntitiesSection.Services.Interfaces;
public interface IPostFeedbackService
{
    Task ClapAsync(Guid postId, Guid userId);
}