using System.Linq.Expressions;
using Shared.Models.Common;

namespace Shared.Models.Entities;

public class SavedPost : SoftDeletedEntity
{
    public Guid UserId { get; set; }
    public Guid PostId { get; set; }

    public SavedPost()
    {

    }

    public SavedPost(Guid id,Guid userId, Guid postId)
    {
        Id = id;
        UserId = userId;
        PostId = postId;
    }
}