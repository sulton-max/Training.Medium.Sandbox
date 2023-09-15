using Shared.Models.Common;

namespace Shared.Models.Entities;

public class PostFeedback : SoftDeletedEntity
{
    public Guid UserId { get; set; }
    public Guid PostId { get; set; }
    public int UserClaps { get; set; }
    public int ClapsLimit = 50;

    public PostFeedback(Guid userId, Guid postId, int userClaps = 1)
    {
        Id = Guid.NewGuid();
        UserId = userId;
        PostId = postId;
        UserClaps = userClaps;
    }
}