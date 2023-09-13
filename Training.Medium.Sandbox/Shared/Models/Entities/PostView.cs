using Shared.Models.Common;

namespace Shared.Models.Entities;

public class PostView : SoftDeletedEntity
{
    public Guid PostId { get; set; }
    public Guid UserId { get; set; }

    public PostView(Guid postId, Guid userId)
    {
        PostId = postId;
        UserId = userId;
    }
}