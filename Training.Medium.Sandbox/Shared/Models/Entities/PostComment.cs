using Shared.Models.Common;

namespace Shared.Models.Entities
{
    public class PostComment : SoftDeletedEntity
    {
        public Guid PostId { get; set; }

        public Guid CommenterId { get; set; }

        public string Message { get; set; }
    }
}
