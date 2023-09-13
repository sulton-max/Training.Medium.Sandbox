using Shared.Models.Common;

namespace Shared.Models.Entities;

public class PostView : SoftDeletedEntity
{
    public Guid UserId { get; set; }
    public Guid PostId { get; set; }
}